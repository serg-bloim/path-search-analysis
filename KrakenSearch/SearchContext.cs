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
            return mapUnit.Interaction.CheckWalkableForUnit(to.x, to.y, staticOnly);
        }

        internal bool isFinalState(Point state)
        {
            return destination.contains(state);
        }

        internal int travelCost(Point @from, Point to)
        {
            if (to.isDiagonal(from))
            {
                return 15;
            }
            else
            {
                return 10;
            }
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
            bool staticOnly, int limits, NeighborStrategy neighborStrategy = NeighborStrategy.FOUR)
        {
            this.mapUnit = mapUnit;
            this.distance = distance;
            this.staticOnly = staticOnly;
            this.limits = limits;
            this.start = start;
            this.destination = destination;
            this.neighborStrategy = neighborStrategy;
        }
    }
}