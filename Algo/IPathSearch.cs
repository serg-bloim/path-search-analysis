using System.Collections.Generic;

namespace Algo
{
    public interface IPathSearch
    {
        IterStatus status { get; }
        ICollection<Point> getVisitedPoints();
        ICollection<Point> getFrontierPoints();
        int getIterNum();
        IterStatus runIter();
    }
}