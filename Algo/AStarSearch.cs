using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{
    public class AStarSearch : BasePathSearch<int>
    {

        public override string name => "A*";

        internal override void initInternal(SearchContext ctx)
        {
            frontier.Enqueue(ctx.startCell, heuristic(ctx.startCell));
        }

        public override IterStatus runIterInternal()
        {
            if (this.status.HasFlag(IterStatus.FINISHED))
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
            else if (frontier.PeekPriority() > distMap[ctx.dstCell]){
                // It's impossible to improve the dist point.
                status |= IterStatus.FINISHED | IterStatus.FOUND | IterStatus.OPTIMAL;
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
                    int dist = distMap[from] + 1;
                    distMap[to] = dist;
                    int f = heuristic(to);
                    frontier.Enqueue(to, f);
                    if (to == ctx.dstCell)
                    {
                        return IterStatus.FOUND;
                    }
                }
            }
            return IterStatus.NONE;
        }

        internal virtual int heuristic(Point to)
        {
            return distMap[to] + Utils.dist(to, ctx.dstCell);
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
            var list = new List<Point>();
            foreach(var e in frontier.queue.data)
            {
                list.Add(e.value);
            }
            return list;
        }

    }
}
