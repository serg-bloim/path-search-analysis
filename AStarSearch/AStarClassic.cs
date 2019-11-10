using System.Collections.Generic;
using SearchPathApi;

namespace Algo
{
    public class AStarClassic : ISearchAlgorithm<Point>
    {
        protected SearchContext<Point> ctx;
        public Map<int> distMap;
        public Map<CellFlags> pathFlagsMap;
        public PriorityQueue<Point, int> frontier = new PriorityQueue<Point, int>();
        private Point dstCell;
        private IterStatus status;

        private void init(SearchContext<Point> searchContext)
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
        public ISearchResult<Point> search(SearchContext<Point> ctx)
        {
            init(ctx);
            for (int i = 0; i < 10; i++)
            {
                runIter();
            }

            return new StandardSearchResult<Point>(SearchState.FOUND, new List<Point>());
        }
        
        public IterStatus runIter()
        {
            if (status.ContainsFlag(IterStatus.FINISHED))
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
                    if (ctx.isFinalState(to))
                    {
                        return IterStatus.FOUND;
                    }
                }
            }
            return IterStatus.NONE;
        }
        
        internal virtual int heuristic(Point to)
        {
            var estimation = ctx.estimateCost(to);
            return distMap[to] + estimation;
        }
    }
}
