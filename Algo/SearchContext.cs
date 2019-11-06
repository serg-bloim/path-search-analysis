
using System;

namespace Algo
{
    public class SearchContext
    {
        public Map<Cell> map;
        public Point startCell;
        public Point dstCell;

        public SearchContext(Map<Cell> map, Point startCell, Point destCell)
        {
            this.map = map;
            this.startCell = startCell;
            this.dstCell = destCell;
        }

        internal bool isWalkable(Point to)
        {
            return map[to].isWalkable;
        }

        internal int heuristic(Point to)
        {
            return diff(to.x, dstCell.x) + diff(to.y, dstCell.y);
        }

        private int diff(int a, int b)
        {
            int res = a - b;
            if (res < 0)
            {
                res = -res;
            }
            return res;
        }
    }
}