
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
    }
}