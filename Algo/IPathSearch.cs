using System.Collections.Generic;

namespace Algo
{
    public interface IPathSearch
    {
        string name { get; }
        IterStatus status { get; }

        void init(SearchContext ctx);
        ICollection<Point> getVisitedPoints();
        ICollection<Point> getFrontierPoints();
        int getIterNum();
        IterStatus runIter();
    }
}