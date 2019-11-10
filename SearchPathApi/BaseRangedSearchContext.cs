using System;
using System.Collections.Generic;

namespace SearchPathApi
{
    public abstract class BaseRangedSearchContext : SearchContext<XYLocation>
    {
        private int destMinX;
        private int destMaxX;
        private int destMinY;
        private int destMaxY;
        private float distance;
        public int width { get; }
        public int height { get; }
        public XYLocation start { get; }

        protected BaseRangedSearchContext(int width, int height, XYLocation start, XYLocation destinationTopLeft,
            XYLocation destinationBottomRight, float distance)
        {
            this.width = width;
            this.height = height;
            this.start = start;
            destMinX = Math.Min(destinationTopLeft.x, destinationBottomRight.x);
            destMaxX = Math.Max(destinationTopLeft.x, destinationBottomRight.x);
            destMinY = Math.Min(destinationTopLeft.y, destinationBottomRight.y);
            destMaxY = Math.Max(destinationTopLeft.y, destinationBottomRight.y);
            this.distance = distance;
        }

        public abstract bool isWalkable(XYLocation @from, XYLocation to);

        public bool isFinalState(XYLocation state)
        {
            var x = state.x;
            var y = state.y;
            if (x > destMinX && x < destMaxX)
            {
                return y > destMinY - distance && y < destMaxY + distance;
            }

            if (y > destMinY && y < destMaxY)
            {
                return x > destMinX - distance && x < destMaxX + distance;
            }

            var cx = x < destMinX ? destMinX : destMaxX;
            var cy = y < destMinY ? destMinY : destMaxY;
            return pow2(x - cx) + pow2(y - cy) <= distance * distance;
        }

        private int pow2(int a) => a * a;

        public ICollection<XYLocation> getNeighbors(XYLocation p)
        {
            var list = new List<XYLocation>();
            list.Add(p.offset(1, 0));
            list.Add(p.offset(0, 1));
            list.Add(p.offset(-1, 0));
            list.Add(p.offset(0, -1));
            return list;
        }

        public abstract int travelCost(XYLocation @from, XYLocation to);

        public int estimateCost(XYLocation @from)
        {
            var cx = from.x < destMinX ? destMinX : destMaxX;
            var cy = from.y < destMinY ? destMinY : destMaxY;
            return abs(from.x - cx) + abs(from.y - cy);
        }

        private int abs(int a) => a > 0 ? a : -a;
    }
}