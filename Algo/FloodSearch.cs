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
    public enum Direction2D
    {
        TOP,
        BOTTOM, 
        LEFT,
        RIGHT,
    }

    public class FloodSearch
    {
        private int[,] pathMap;
        private Map map;
        LinkedList<Point> frontier = new LinkedList<Point>();
        private SearchContext ctx;

        public FloodSearch(Map map)
        {
            this.map = map;
            pathMap = new int[map.width, map.height];
            frontier.AddLast(map.startCell);
            pathMap[map.startCell] = 0;
        }

        public FloodSearch(SearchContext ctx)
        {
            this.ctx = ctx;
        }

        public IterStatus iter()
        {
            if (frontier.Count == 0)
            {
                return IterStatus.FINISHED;
            }
            Point p = PollFirst();
            if(p == map.destCell)
            {
                return IterStatus.FINISHED | IterStatus.FOUND;
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
