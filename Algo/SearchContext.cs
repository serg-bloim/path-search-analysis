
namespace Algo
{
    public class SearchContext
    {
        private Map map;
        private Point startCell;
        private Point destCell;

        public SearchContext(Map map, Point startCell, Point destCell)
        {
            this.map = map;
            this.startCell = startCell;
            this.destCell = destCell;
        }
    }
}