using System.Collections.Generic;

namespace SearchPathApi
{
    public interface ISearchResult<State>
    {
        SearchState getSearchState();

        List<State> getPath();
    }
}