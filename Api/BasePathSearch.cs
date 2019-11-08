using System;
using System.Collections.Generic;

namespace Algo
{
    public abstract class BasePathSearch<T> : IPathSearch where T:IComparable<T>
    {
        int iters = 0;
        protected SearchContext ctx;
        public Map<int> distMap;
        public Map<CellFlags> pathFlagsMap;
        public PriorityQueue<Point, T> frontier = new PriorityQueue<Point, T>();

        public IterStatus status { get; set; }
        public abstract string name { get; }

        public abstract ICollection<Point> getFrontierPoints();
        public int getIterNum()
        {
            return iters;
        }
        public abstract ICollection<Point> getVisitedPoints();

        public void init(SearchContext ctx)
        {
            this.ctx = ctx;
            pathFlagsMap = new Map<CellFlags>(ctx.width, ctx.height);
            distMap = new Map<int>(ctx.width, ctx.height);
            frontier = new PriorityQueue<Point, T>();
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
            status = IterStatus.NONE;
            iters = 0;
            initInternal(ctx);
        }
        protected abstract void initInternal(SearchContext ctx);

        public IterStatus runIter()
        {
            if (this.status.HasFlag(IterStatus.FINISHED))
            {
                return this.status;
            }
            iters++;
            return runIterInternal();
        }

        public abstract IterStatus runIterInternal();
    }
}