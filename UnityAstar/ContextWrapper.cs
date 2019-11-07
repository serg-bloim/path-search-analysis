using System.Collections.Generic;
using Algo;

namespace UnityAstar
{
    internal class ContextWrapper : UnitAstarHelper
    {
        private SearchContext ctx;

        public ContextWrapper(SearchContext ctx) :base(new UnitMock(ctx))
        {
            this.ctx = ctx;
            MapLogic.Instance.Width = ctx.width;
            MapLogic.Instance.Height = ctx.height;
        }
    }
}