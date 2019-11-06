namespace Algo
{
    public interface IPathSearch
    {
        IterStatus status { get; }
        Map<CellFlags> pathFlagsMap { get; }
        Map<int> distMap { get; }

        IterStatus iter();
    }
}