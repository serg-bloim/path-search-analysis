using System.Collections.Generic;

namespace Algo
{
    public interface IPathSearch
    {
        IterStatus status { get; }
        List<Point> getVisitedPoints();
        List<Point> getFrontierPoints();
        IterStatus iter();
    }
}