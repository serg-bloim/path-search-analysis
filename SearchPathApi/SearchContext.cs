using System.Collections.Generic;

namespace SearchPathApi
{
    public interface SearchContext<State>
    {
        int width { get; }
        int height { get; }
        State start { get; }
        bool isWalkable(State from, State to);
        bool isFinalState(State state);
        ICollection<State> getNeighbors(State p);
        int travelCost(State @from, State to);
        int estimateCost(State @from);
    }
}