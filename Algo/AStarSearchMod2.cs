using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{

    public class AStarSearchMod2 : IPathSearch
    {
        public struct PriorityEntry : IComparable<PriorityEntry>
        {
            public int total;
            public double remaining;
            public int CompareTo(PriorityEntry other)
            {
                if (total == other.total)
                {
                    return remaining.CompareTo(other.remaining);
                }
                else
                {
                    return total.CompareTo(other.total);
                }
            }
        }
        public Map<int> distMap { get; private set; }
        public Map<CellFlags> pathFlagsMap { get; private set; }
        private Map<Cell> map;
        public PriorityQueue<Point, PriorityEntry> frontier = new PriorityQueue<Point, PriorityEntry>();
        private SearchContext ctx;
        public IterStatus status { get; private set; } = IterStatus.NONE;

        public AStarSearchMod2(SearchContext ctx)
        {
            this.ctx = ctx;
            map = ctx.map;
            frontier.Enqueue(ctx.startCell, new PriorityEntry { total = ctx.heuristic(ctx.startCell), remaining = Utils.dist(ctx.startCell, ctx.dstCell) });
            pathFlagsMap = new Map<CellFlags>(map.width, map.height);
            distMap = new Map<int>(map.width, map.height);
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

        public IterStatus iter()
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
            else if (frontier.PeekPriority().total > distMap[ctx.dstCell])
            {
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
                    var angle = AngleBetween(ctx.startCell, ctx.dstCell, to);
                    int f = dist + ctx.heuristic(to) +(int)angle;
                    frontier.Enqueue(to, new PriorityEntry { total = f, remaining = angle });
                    if (to == ctx.dstCell)
                    {
                        return IterStatus.FOUND;
                    }
                }
            }
            return IterStatus.NONE;
        }
        public static double AngleBetween(Point origin, Point vector1, Point vector2)
        {
            double theta1 = Math.Atan2(origin.y - vector1.y, origin.x - vector1.x);
            double theta2 = Math.Atan2(origin.y - vector2.y, origin.x - vector2.x);

            return Math.Abs(theta1 - theta2) * 180 / Math.PI;
        }
    }
}
