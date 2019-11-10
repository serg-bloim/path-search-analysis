﻿using System.Collections.Generic;
using System.MapLogic.KrakenSearch;
using Algo;
using CellFlags = System.MapLogic.KrakenSearch.CellFlags;
using IterStatus = Algo.IterStatus;
using Point = Algo.Point;
using SearchContext = Algo.SearchContext;

namespace KrakenSearchUIIntegration
{
    public class KrakenWrapper : IPathSearch
    {
        private SearchContext ctx;
        KrakenSearch algo = new KrakenSearch();
        private SearchState state = SearchState.NONE;
        public string name => "Kraken";
        public IterStatus status { get; } = IterStatus.NONE;
        public void init(SearchContext ctx)
        {
            this.ctx = ctx;
            Interaction.walkChecker = (int x, int y) => ctx.isWalkable(Point.of(x, y));
            Interaction.width = ctx.width;
            Interaction.height = ctx.height;
            algo.init(new System.MapLogic.KrakenSearch.SearchContext(new MapUnit(), toKraken(ctx.startCell),
                Region.fromSinglePoint(toKraken(ctx.dstCell)), 0, true));
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

        public int getIterNum() => algo.iters;

        public IterStatus runIter()
        {
            state |= algo.runIter(state);
            return toIterStatus(state);
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