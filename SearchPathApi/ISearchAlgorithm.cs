namespace SearchPathApi
{
    public interface ISearchAlgorithm<State>
    {
        ISearchResult<State> search(State from, State to, SearchContext<State> ctx);
    }
}