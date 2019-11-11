using System.Collections.Generic;
using System.ComponentModel;

namespace System.MapLogic.KrakenSearch
{
    public class SearchContext
    {
        private readonly MapUnit mapUnit;
        private readonly float distance;
        private readonly bool staticOnly;
        private readonly int limits;
        internal int width;
        internal int height;
        internal Point start;
        private Region destination;
        private NeighborStrategy neighborStrategy = NeighborStrategy.FOUR;

        internal bool isWalkable(Point from, Point to)
        {
            if (limits > 0)
            {
                if (to.x < start.x - limits || to.x > start.x + limits ||
                    to.y < start.y - limits || to.y > start.y + limits)
                    return false;
            }

            return mapUnit.Interaction.CheckWalkableForUnit(to.x, to.y, staticOnly);
        }

        internal bool isFinalState(Point p)
        {
            if (p.x >= destination.lower.x && p.x <= destination.upper.x)
            {
                return p.y >= destination.lower.y - distance && p.y <= destination.upper.y + distance;
            }
            if (p.y >= destination.lower.y && p.y <= destination.upper.y)
            {
                return p.x >= destination.lower.x - distance && p.x <= destination.upper.x + distance;
            }
            var cx = p.x < destination.lower.x ? destination.lower.x : destination.upper.x;
            var cy = p.y < destination.lower.y ? destination.lower.y : destination.upper.y;
            return pow2(p.x - cx) + pow2(p.y - cy) <= distance * distance;
        }

        private static int pow2(int a)
        {
            return a*a;
        }

        internal int travelCost(Point @from, Point to)
        {
            if (to.isDiagonal(from))
            {
                return 15;
            }
            return 10;
        }

        internal int estimateCost(Point p)
        {
            int dx = Math.Max(destination.lower.x - p.x, p.x - destination.upper.x);
            int dy = Math.Max(destination.lower.y - p.y, p.y - destination.upper.y);
            switch (neighborStrategy)
            {
                case NeighborStrategy.FOUR:
                    return (dx + dy) * 10;
                case NeighborStrategy.EIGHT:
                {
                    var diag = Math.Min(dx, dy);
                    var straight = (dx + dy) - 2 * diag;
                    return diag + straight;
                }
            }
            throw new InvalidEnumArgumentException($"Unsupported NeighborStrategy value: {neighborStrategy}");
        }

        public SearchContext(MapUnit mapUnit, Point start, Region destination, float distance,
            bool staticOnly, int limits=-1, NeighborStrategy neighborStrategy = NeighborStrategy.FOUR)
        {
            this.mapUnit = mapUnit;
            this.distance = distance;
            this.staticOnly = staticOnly;
            this.limits = limits;
            this.start = start;
            this.destination = destination;
            this.neighborStrategy = neighborStrategy;
            width = Interaction.width;
            height = Interaction.height;
        }
    }
}