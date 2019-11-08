using System.Collections.Generic;

namespace SearchPathApi
{
    public class StandardSearchResult<State> : ISearchResult<State>
    {
        private SearchState status;
        private List<State> path;

        public StandardSearchResult(SearchState status, List<State> path)
        {
            this.status = status;
            this.path = path;
        }

        public SearchState getSearchState()
        {
            return status;
        }

        public List<State> getPath()
        {
            return path;
        }
    }
}