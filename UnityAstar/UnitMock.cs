using Algo;

namespace UnityAstar
{
    internal class UnitMock : MapUnit
    {
        private SearchContext ctx;
        private UnitInteraction inter;

        public UnitMock(SearchContext ctx)
        {
            this.ctx = ctx;
            inter = new MockInteraction(ctx);
        }

        public override UnitInteraction Interaction { get => inter; }
    internal class MockInteraction : UnitInteraction
    {
            private SearchContext ctx;

            public MockInteraction(SearchContext ctx)
            {
                this.ctx = ctx;
            }

            public bool CheckWalkableForUnit(int x, int y, bool staticLookup)
        {
                return ctx.isWalkable(Point.of(x, y));
        }
    }
    }

}