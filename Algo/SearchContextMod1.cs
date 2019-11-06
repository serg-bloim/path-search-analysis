namespace Algo
{
    public class SearchContextMod1 : SearchContext
    {
        public SearchContextMod1(Map<Cell> map, Point startCell, Point destCell) : base(map, startCell, destCell)
        {
        }

        internal override int heuristic(Point to)
        {
            return base.heuristic(to)*2;
        }
    }
}