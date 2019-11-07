
using System;

namespace Algo
{
    public class SearchContext
    {
        private Map<Cell> map;
        public readonly Point startCell;
        public readonly Point dstCell;
        public readonly int width;
        public readonly int height;

        public SearchContext(Map<Cell> map, Point startCell, Point destCell)
        {
            this.map = map;
            width = map.width;
            height = map.height;
            this.startCell = startCell;
            this.dstCell = destCell;
        }

        internal bool isWalkable(Point to)
        {
            return map[to].isWalkable;
        }
    }
}