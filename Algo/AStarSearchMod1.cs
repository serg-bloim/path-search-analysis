using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{

    public class AStarSearchMod1 : IPathSearch
    {
        public struct PriorityEntry : IComparable<PriorityEntry>
        {
            public int total;
            public int remaining;
            public int CompareTo(PriorityEntry other)
            {
                if(total == other.total)
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

        public AStarSearchMod1(SearchContext ctx)
        {
            this.ctx = ctx;
            map = ctx.map;
            frontier.Enqueue(ctx.startCell, new PriorityEntry { total = ctx.heuristic(ctx.startCell) , remaining = Utils.dist(ctx.startCell, ctx.dstCell)});
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
            else if (frontier.PeekPriority().total > distMap[ctx.dstCell]){
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
                    int h = ctx.heuristic(to);
                    int f = dist + h;
                    frontier.Enqueue(to, new PriorityEntry { total = f, remaining = h});
                    if (to == ctx.dstCell)
                    {
                        return IterStatus.FOUND;
                    }
                }
            }
            return IterStatus.NONE;
        }
    }
}
