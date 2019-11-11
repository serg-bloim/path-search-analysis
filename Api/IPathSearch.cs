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
        ICollection<Point> getPath();
        int getIterNum();
        IterStatus runIter();
    }
    public interface IPathSearch2 : IPathSearch
    {
        int distance { get; set; }
        int limits { get; set; }
        IterStatus runTillEnd();
    }
}