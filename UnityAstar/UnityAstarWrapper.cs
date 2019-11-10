using System;
using System.Collections.Generic;
using System.Text;
using Algo;
using UnityAstar.math;

namespace UnityAstar
{
    class UnityAstarWrapper : IPathSearch
    {
        ShortestPathGraphSearch<Vector2i, Vector2i> algo;
        public string name => "A* Unity";
        Vector2i from, to;
        int iter;

        public IterStatus status { get; set; } =  IterStatus.NONE;

        public void init(SearchContext ctx)
        {
            from = convert(ctx.startCell);
            to = convert(ctx.dstCell);
           algo = new ShortestPathGraphSearch<Vector2i, Vector2i>(new ContextWrapper(ctx));
        }


        public IterStatus runIter()
        {
            algo.GetShortestPath(from, to);
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

        public ICollection<Point> getPath()
        {
            return new List<Point>();
        }

        public int getIterNum()
        {
            return algo.exploredSet.Count;
        }

        public ICollection<Point> getVisitedPoints()
        {
            var list = new List<Point>(getIterNum());
            foreach(var v in algo.exploredSet)
            {
                list.Add(Point.of(v.x, v.y));
            }
            return list;
        }

    }
}
