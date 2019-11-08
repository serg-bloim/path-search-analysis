using System.Collections.Generic;

namespace SearchPathApi
{
    public interface SearchContext<State>
    {
        bool isWalkable(State from, State to);
        ICollection<State> getNeighbors(State p);
        int width { get; }
        int height { get; }
    }
}