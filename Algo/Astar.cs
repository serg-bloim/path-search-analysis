using System;
using System.Collections.Generic;
using System.Text;
using SearchPathApi;

namespace Algo
{
    public class AStar : ISearchAlgorithm<Point>
    {
        protected SearchContext<Point> ctx;
        public Map<int> distMap;
        public Map<CellFlags> pathFlagsMap;
        public PriorityQueue<Point, int> frontier = new PriorityQueue<Point, int>();
        private Point dstCell;
        
        public IterStatus status { get; set; }

        private void init(Point from, Point to, SearchContext<Point> searchContext)
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
            distMap[from] = 0;
            pathFlagsMap[from] = CellFlags.VISITED | CellFlags.FRONTIER | CellFlags.START;
            pathFlagsMap[to] = CellFlags.END;
            status = IterStatus.NONE;
            frontier.Enqueue(from, heuristic(from));
        }
        public ISearchResult<Point> search(Point from, Point to, SearchContext<Point> ctx)
        {
            init(from, to, ctx);
            for (int i = 0; i < 10; i++)
            {
                runIter();
            }

            return new StandardSearchResult<Point>(SearchState.FOUND, new List<Point>());
        }
        
        public IterStatus runIter()
        {
            if (this.status.ContainsFlag(IterStatus.FINISHED))
            {
                return this.status;
            }
            return runIterInternal();
        }
        public  IterStatus runIterInternal()
        {
            if (this.status.ContainsFlag(IterStatus.FINISHED))
            {
                return this.status;
            }
            Point p = frontier.Dequeue();
            pathFlagsMap[p] &= ~CellFlags.FRONTIER;
            status |= processCandidate(p, p.left());
            status |= processCandidate(p, p.right());
            status |= processCandidate(p, p.up());
            status |= processCandidate(p, p.down());
            if (frontier.Count() == 0)
            {
                status |= IterStatus.FINISHED;
            }
            else if (frontier.PeekPriority() > distMap[dstCell]){
                // It's impossible to improve the dist point.
                status |= IterStatus.FINISHED | IterStatus.FOUND | IterStatus.OPTIMAL;
            }
            return status;
        }

        private IterStatus processCandidate(Point from, Point to)
        {
            if (ctx.isWalkable(from, to))
            {
                CellFlags flags = pathFlagsMap[to];
                if (!flags.ContainsFlag(CellFlags.VISITED))
                {
                    pathFlagsMap[to] = flags | CellFlags.VISITED | CellFlags.FRONTIER;
                    int dist = distMap[from] + ctx.travelCost(from, to);
                    distMap[to] = dist;
                    int f = heuristic(to);
                    frontier.Enqueue(to, f);
                    if (to == dstCell)
                    {
                        return IterStatus.FOUND;
                    }
                }
            }
            return IterStatus.NONE;
        }
        
        internal virtual int heuristic(Point to)
        {
            var dist = Utils.dist(to, dstCell);
            return distMap[to] + dist;
        }
        
    }

    static class Extensions
    {
        public static bool ContainsFlag(this CellFlags flags, CellFlags flag)
        {
            return (flags & flag) != 0;
        }
        public static bool ContainsFlag(this IterStatus flags, IterStatus flag)
        {
            return (flags & flag) != 0;
        }
    }
}
