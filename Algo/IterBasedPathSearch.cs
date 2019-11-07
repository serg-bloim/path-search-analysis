using System.Collections.Generic;

namespace Algo
{
    public abstract class IterBasedPathSearch : IPathSearch
    {
        int iters = 0;
        public IterStatus status { get; set;  }

        public abstract ICollection<Point> getFrontierPoints();
        public int getIterNum()
        {
            return iters;
        }
        public abstract ICollection<Point> getVisitedPoints();

        public IterStatus runIter()
        {
            if (this.status.HasFlag(IterStatus.FINISHED))
            {
                return this.status;
            }
            iters++;
            return runIterInternal();
        }

        public abstract IterStatus runIterInternal();
    }
}