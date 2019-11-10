using System.Collections.Generic;

namespace System.MapLogic.KrakenSearch
{
    public interface ISearchResult<State>
    {
        SearchState getSearchState();

        List<State> getPath();
    }
}