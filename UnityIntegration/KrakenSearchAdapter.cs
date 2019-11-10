using System.Collections.Generic;

namespace System.MapLogic.KrakenSearch
{
    public class KrakenSearchAdapter
    {
        private KrakenSearch algorithm;

        public List<Vector2i> FindPath(MapUnit mapUnit, int x, int y, int topleftX, int topleftY, int bottomRightX,
            int bottomRightY, float distance, bool staticOnly, int limits = -1)
        {
            Point start = Point.of(x, y);
            Region destination;
            destination.lower.x = Utils.min(topleftX, bottomRightX);
            destination.lower.y = Utils.min(topleftY, bottomRightY);
            destination.upper.x = Utils.max(topleftX, bottomRightX);
            destination.upper.y = Utils.max(topleftY, bottomRightY);
            var result = algorithm.search(new SearchContext(mapUnit, start, destination, distance, staticOnly, limits));
            if (result.getSearchState() == SearchState.FOUND)
            {
                return Utils.toVectors(result.getPath());
            }
            return null;
        }
    }
}