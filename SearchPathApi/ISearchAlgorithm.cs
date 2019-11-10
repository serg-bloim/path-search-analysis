namespace SearchPathApi
{
    public interface ISearchAlgorithm<State>
    {
        ISearchResult<State> search(SearchContext<State> ctx);
    }
}