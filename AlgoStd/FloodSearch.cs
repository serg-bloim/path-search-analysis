using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{
    public class FloodSearch : BasePathSearch<int>
    {
        LinkedList<Point> frontier = new LinkedList<Point>();

        public override string name => "Flood";

        protected override void initInternal(SearchContext ctx)
        {
            frontier = new LinkedList<Point>();
            frontier.AddFirst(ctx.startCell);
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
