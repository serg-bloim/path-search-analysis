using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{

    public class AStarSearchMod1 : AStarSearch
    {

        public override string name => "A* - mod1";

        internal override int heuristic(Point to)
        {
            return base.heuristic(to) + 5*Utils.dist(to, ctx.dstCell);
        }
    }
}
