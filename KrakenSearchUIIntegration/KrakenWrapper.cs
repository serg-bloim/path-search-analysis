using System.Collections.Generic;
using System.MapLogic.KrakenSearch;
using Algo;
using CellFlags = System.MapLogic.KrakenSearch.CellFlags;
using IterStatus = Algo.IterStatus;
using Point = Algo.Point;
using SearchContext = Algo.SearchContext;

namespace KrakenSearchUIIntegration
{
    public class KrakenWrapper : IPathSearch2
    {
        private SearchContext ctx;
        KrakenSearch algo = new KrakenSearch();
        private SearchState state = SearchState.NONE;
        private int iters;
        private List<Point> path = new List<Point>();
        public string name => "Kraken";
        public IterStatus status { get; set; } = IterStatus.NONE;
        public int distance { get; set; }
        public int limits { get; set; }
        
        public void init(SearchContext ctx)
        {
            this.ctx = ctx;
            iters = 0;
            state = SearchState.NONE;
            Interaction.walkChecker = (int x, int y) => ctx.isWalkable(Point.of(x, y));
            Interaction.width = ctx.width;
            Interaction.height = ctx.height;
            algo.init(new System.MapLogic.KrakenSearch.SearchContext(new MapUnit(), toKraken(ctx.startCell),
                Region.fromSinglePoint(toKraken(ctx.dstCell)), distance, true, limits, NeighborStrategy.EIGHT));
        }

        public ICollection<Point> getVisitedPoints()
        {
            var list = new List<Point>();
            if (algo.pathFlagsMap == null)
            {
                return list;
            }
            algo.pathFlagsMap.Foreach((x, y, f) =>
            {
                if (f.ContainsFlag(CellFlags.VISITED))
                {
                    list.Add(Point.of(x, y));
                }
            });
            return list;
        }

        public ICollection<Point> getFrontierPoints()
        {
            var list = new List<Point>();
            if (algo.frontier == null)
            {
                return list;
            }

            for (int i = 0; i < algo.frontier.Count(); i++)
            {
                var p = algo.frontier.queue.data[i].value;
                list.Add(Point.of(p.x, p.y));
            }
            return list;
        }

        public ICollection<Point> getPath()
        {
            return path;
        }

        public int getIterNum() => iters;

        public IterStatus runIter()
        {
            iters++;
            state |= algo.runIter(state);
            status = toIterStatus(state);
            return status;
        }


        public IterStatus runTillEnd()
        {
            var searchResult = algo.search();
            state =searchResult.getSearchState();
            status = toIterStatus(state);
            path = new List<Point>();
            if (state.ContainsFlag(SearchState.FINISHED))
            {
                foreach (var p in searchResult.getPath())
                {
                    path.Add(Point.of(p.x, p.y));
                }
            }
            return status;
        }

        private IterStatus toIterStatus(SearchState s)
        {
            return (IterStatus) s;
        }

        private System.MapLogic.KrakenSearch.Point toKraken(Point p)
        {
            System.MapLogic.KrakenSearch.Point kp;
            kp.x = p.x;
            kp.y = p.y;
            return kp;
        }
    }
}