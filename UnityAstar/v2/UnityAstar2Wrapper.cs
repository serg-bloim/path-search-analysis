using System;
using System.Collections.Generic;
using System.Text;
using Algo;
using UnityAstar.math;

namespace UnityAstar
{
    class UnityAstarWrapper2 : IPathSearch
    {
        private SearchContext ctx;
        AstarPathfinder algo;
        public string name => "A* Unity v2";
        Vector2i from, to;
        int iter;

        public IterStatus status { get; set; } =  IterStatus.NONE;

        public void init(SearchContext ctx)
        {
            from = convert(ctx.startCell);
            to = convert(ctx.dstCell);
            var helper = new ContextWrapper(ctx);
            this.ctx = ctx;
            algo = new AstarPathfinder();
        }


        public IterStatus runIter()
        {
            if( null != algo.FindPath(new UnitMock(ctx), ctx.startCell.x, ctx.startCell.y, ctx.dstCell.x, ctx.dstCell.y, ctx.dstCell.x, ctx.dstCell.y, 0, true))
            {
                status |= IterStatus.FOUND;
            }
            status =IterStatus.FINISHED;
            return status;
        }
        private Vector2i convert(Point p)
        {
            return new Vector2i(p.x, p.y);
        }

        public ICollection<Point> getFrontierPoints()
        {
            return new List<Point>();
        }

        public int getIterNum()
        {
            return algo.closedNodes.Count;
        }

        public ICollection<Point> getVisitedPoints()
        {
            var list = new List<Point>(getIterNum());
            foreach(var v in algo.closedNodes)
            {
                int x = v.getX();
                int y = v.getY();
                list.Add(Point.of(x,y));
            }
            return list;
        }

    }
}
