using System;
using System.Collections.Generic;

namespace SearchPathApi
{
    public abstract class BaseSinglePointSearchContext :SearchContext<XYLocation>
    {
        public int width { get; }
        public int height { get; }
        public XYLocation start { get; }
        public XYLocation destination { get; }

        protected BaseSinglePointSearchContext(int width, int height, XYLocation start, XYLocation destination)
        {
            this.width = width;
            this.height = height;
            this.start = start;
            this.destination = destination;
        }

        public abstract bool isWalkable(XYLocation @from, XYLocation to);

        public bool isFinalState(XYLocation state)
        {
            return XYLocationExtensions.@equals(state, destination);
        }

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
            return Math.Abs(from.x - destination.x) + Math.Abs(from.y - destination.y);
        }
    }
}