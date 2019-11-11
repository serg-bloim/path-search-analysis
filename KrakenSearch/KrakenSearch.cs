using System;
using System.Collections.Generic;

namespace System.MapLogic.KrakenSearch
{
    public class KrakenSearch
    {
        private Point foundDest;
        protected SearchContext ctx;
        public Map<int> distMap;
        public Map<CellFlags> pathFlagsMap;
        public Map<Point> backtrack;
        public PriorityQueue<Point, int> frontier = new PriorityQueue<Point, int>();
        private static int MAXIMUM_ITERS = 10000;
        private NeighborStrategy neighborStrategy = NeighborStrategy.FOUR;
        public int iters;
        private int dstCost = Int32.MaxValue;
        private int closestH = Int32.MaxValue;

        public void init(SearchContext ctx)
        {
            this.ctx = ctx;
            pathFlagsMap = new Map<CellFlags>(ctx.width, ctx.height);
            distMap = new Map<int>(ctx.width, ctx.height);
            backtrack = new Map<Point>(ctx.width, ctx.height);
            frontier = new PriorityQueue<Point, int>();
            for (int x = 0; x < distMap.width; x++)
            {
                for (int y = 0; y < distMap.height; y++)
                {
                    distMap[x, y] = int.MaxValue;
                }
            }

            foundDest = ctx.start;
            distMap[ctx.start] = 0;
            dstCost = Int32.MaxValue;
            closestH = Int32.MaxValue;
            pathFlagsMap[ctx.start] = CellFlags.VISITED | CellFlags.FRONTIER | CellFlags.START;
            frontier.Enqueue(ctx.start, heuristic(ctx.start));
            iters=0;
        }

        private int heuristic(Point p)
        {
            return distMap[p] + ctx.estimateCost(p);
        }

        public ISearchResult<Point> search()
        {
            SearchState stat = SearchState.NONE;
            for (int i = 0; i < MAXIMUM_ITERS; i++)
            {
                stat |= runIter(stat);
                if (stat.ContainsFlag(SearchState.FINISHED))
                {
                    iters = i;
                    break;
                }
            }

            return new StandardSearchResult<Point>(stat, buildPath());
        }

        public List<Point> buildPath()
        {
            var path = new List<Point>();
            Point p = foundDest;
            while (p != ctx.start)
            {
                path.Add(p);
                p = backtrack[p];
            }

            return path;
        }

        public SearchState runIter(SearchState status)
        {
            iters++;
            Point p = frontier.Dequeue();
            pathFlagsMap[p] &= ~CellFlags.FRONTIER;
            status |= processCandidate(p, p.left());
            status |= processCandidate(p, p.right());
            status |= processCandidate(p, p.up());
            status |= processCandidate(p, p.down());
            if (neighborStrategy == NeighborStrategy.EIGHT)
            {
                status |= processCandidate(p, p.left().up());
                status |= processCandidate(p, p.left().down());
                status |= processCandidate(p, p.right().up());
                status |= processCandidate(p, p.right().down());
            }

            if (frontier.Count() == 0)
            {
                status |= SearchState.FINISHED;
            }
            else if (frontier.PeekPriority() > dstCost)
            {
                // It's impossible to improve the dist point.
                status |= SearchState.FINISHED | SearchState.FOUND | SearchState.OPTIMAL;
            }

            return status;
        }

        private SearchState processCandidate(Point from, Point to)
        {
            if (ctx.isWalkable(from, to))
            {
                CellFlags flags = pathFlagsMap[to];
                var curr_dist = distMap[to];

                if (!flags.ContainsFlag(CellFlags.VISITED))
                {
                    curr_dist = int.MaxValue;
                }

                int new_dist = distMap[from] + ctx.travelCost(from, to);
                if (new_dist < curr_dist) //update then
                {
                    pathFlagsMap[to] = flags | CellFlags.VISITED | CellFlags.FRONTIER | Utils.getDirection(from, to);

                    backtrack[to] = from;
                    distMap[to] = new_dist;
                    var h = ctx.estimateCost(to);
                    int f = new_dist + h;
                    frontier.Enqueue(to, f);


                    if (ctx.isFinalState(to))
                    {
                        if (new_dist < dstCost)
                        {
                            foundDest = to;
                            dstCost = new_dist;
                        }

                        return SearchState.FOUND;
                    }
                    if (h < closestH)
                    {
                        foundDest = to;
                        closestH = h;
                    }
                }
            }

            return SearchState.NONE;
        }
    }

    public enum NeighborStrategy
    {
        FOUR,
        EIGHT
    }
}