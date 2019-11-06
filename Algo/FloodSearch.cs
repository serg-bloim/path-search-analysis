using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{
    [Flags]
    public enum IterStatus
    {
        NONE = 0,
        FINISHED,
        FOUND
    }
    [Flags]
    public enum CellFlags
    {
        TOP         = 0b1, 
        LEFT        = 0b10,
        VISITED     = 0b100,
        FRONTIER    = 0b1000,
        START       = 0b10000,
        END         = 0b100000,
    }

    public class FloodSearch
    {
        public Map<int> distMap;
        public Map<CellFlags> pathFlagsMap;
        private Map<Cell> map;
        LinkedList<Point> frontier = new LinkedList<Point>();
        private SearchContext ctx;
        public IterStatus status { get; private set; } = IterStatus.NONE;

        public FloodSearch(SearchContext ctx)
        {
            this.ctx = ctx;
            map = ctx.map;
            frontier.AddFirst(ctx.startCell);
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
            if(this.status.HasFlag(IterStatus.FINISHED))
            {
                return this.status;
            }
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
                    if(to == ctx.dstCell)
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
    }
}
