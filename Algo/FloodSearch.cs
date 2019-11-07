using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{
    public class FloodSearch : IterBasedPathSearch
    {
        public Map<int> distMap;
        public Map<CellFlags> pathFlagsMap;
        LinkedList<Point> frontier = new LinkedList<Point>();
        private SearchContext ctx;

        public FloodSearch(SearchContext ctx)
        {
            this.ctx = ctx;
            frontier.AddFirst(ctx.startCell);
            pathFlagsMap = new Map<CellFlags>(ctx.width, ctx.height);
            distMap = new Map<int>(ctx.width, ctx.height);
            for (int x = 0; x < distMap.width; x++)
            {
                for (int y = 0; y < distMap.height; y++)
                {
                    distMap[x, y] = int.MaxValue;
                }
            }
            distMap[ctx.startCell] = 0;
            pathFlagsMap[ctx.startCell] = CellFlags.VISITED | CellFlags.FRONTIER | CellFlags.START;
            pathFlagsMap[ctx.dstCell] = CellFlags.END;
        }

        public override IterStatus runIterInternal()
        {

            Point p = PollFirst();
            pathFlagsMap[p] &= ~CellFlags.FRONTIER;
            status |= processCandidate(p, p.left());
            status |= processCandidate(p, p.right());
            status |= processCandidate(p, p.up());
            status |= processCandidate(p, p.down());
            if (frontier.Count == 0)
            {
                status |= IterStatus.FINISHED;
            }
            return status;
        }

        private IterStatus processCandidate(Point from, Point to)
        {
            if (ctx.isWalkable(to))
            {
                CellFlags flags = pathFlagsMap[to];
                if (!flags.HasFlag(CellFlags.VISITED))
                {
                    pathFlagsMap[to] = flags | CellFlags.VISITED | CellFlags.FRONTIER;
                    frontier.AddLast(to);
                    distMap[to] = distMap[from] + 1;
                    if (to == ctx.dstCell)
                    {
                        return IterStatus.FINISHED | IterStatus.FOUND;
                    }
                }
            }
            return IterStatus.NONE;
        }

        private Point PollFirst()
        {
            var p = frontier.First.Value;
            frontier.RemoveFirst();
            return p;
        }

        public override ICollection<Point> getVisitedPoints()
        {
            List<Point> list = new List<Point>();
            pathFlagsMap.Foreach((int x, int y, CellFlags fs) =>
            {
                if (fs.HasFlag(CellFlags.VISITED))
                {
                    list.Add(Point.of(x, y));
                }
            });
            return list;
        }

        public override ICollection<Point> getFrontierPoints()
        {
            return frontier;
        }
    }
}
