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
        public PriorityQueue<Point, int> frontier = new PriorityQueue<Point, int>();
        private Point dstCell;
        private IterStatus status;
        private static int MAXIMUM_ITERS = 10000;
        private NeighborStrategy neighborStrategy = NeighborStrategy.FOUR;


        private void init(SearchContext searchContext)
        {
            pathFlagsMap = new Map<CellFlags>(ctx.width, ctx.height);
            distMap = new Map<int>(ctx.width, ctx.height);
            frontier = new PriorityQueue<Point, int>();
            for (int x = 0; x < distMap.width; x++)
            {
                for (int y = 0; y < distMap.height; y++)
                {
                    distMap[x, y] = int.MaxValue;
                }
            }
            distMap[ctx.start] = 0;
            pathFlagsMap[ctx.start] = CellFlags.VISITED | CellFlags.FRONTIER | CellFlags.START;
            status = IterStatus.NONE;
            frontier.Enqueue(ctx.start, heuristic(ctx.start));
        }

        private int heuristic(Point p)
        {
            return distMap[p] + ctx.estimateCost(p);
        }

        internal ISearchResult<Point> search(SearchContext searchContext)
        {
            init(ctx);
            SearchState stat = SearchState.NONE;
            for (int i = 0; i < MAXIMUM_ITERS; i++)
            {
                stat |= runIter();
                if (stat.ContainsFlag(SearchState.FINISHED))
                {
                    break;
                }
            }

            return new StandardSearchResult<Point>(stat, buildPath());
        }

        private List<Point> buildPath()
        {
            var path = new List<Point>();
            Point p = foundDest;
            while (p != ctx.start)
            {
                path.Add(p);
                Utils.followBackwards(p, pathFlagsMap[p]);
            }
            return path;
        }

        public SearchState runIter()
        {
            SearchState status = SearchState.NONE;
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
            else if (frontier.PeekPriority() > distMap[dstCell]){
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

                if (flags.ContainsFlag(CellFlags.VISITED))
                {
                    curr_dist = int.MaxValue;
                }
                int new_dist = distMap[from] + ctx.travelCost(from, to);
                if (new_dist > curr_dist)
                {
                    //update then
                    pathFlagsMap[to] = flags | CellFlags.VISITED | CellFlags.FRONTIER | Utils.getDirection(from, to);
                    distMap[to] = new_dist;
                    int f = heuristic(to);
                    frontier.Enqueue(to, f);
                    if (ctx.isFinalState(to))
                    {
                        return SearchState.FOUND;
                    }
                }
                if (!flags.ContainsFlag(CellFlags.VISITED))
                {
                    pathFlagsMap[to] = flags | CellFlags.VISITED | CellFlags.FRONTIER;
                    int dist = distMap[from] + ctx.travelCost(from, to);
                    distMap[to] = dist;
                    int f = heuristic(to);
                    frontier.Enqueue(to, f);
                    if (ctx.isFinalState(to))
                    {
                        return SearchState.FOUND;
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
