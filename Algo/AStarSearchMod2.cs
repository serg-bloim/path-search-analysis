using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{

    public class AStarSearchMod2 : AStarSearch
    { 
        public override string name => "A* - mod2";

        internal override int heuristic(Point to)
        {
            var angle = AngleBetween(ctx.startCell, ctx.dstCell, to);
            return  base.heuristic(to) + (int)angle;
        }

        public static double AngleBetween(Point origin, Point vector1, Point vector2)
        {
            double theta1 = Math.Atan2(origin.y - vector1.y, origin.x - vector1.x);
            double theta2 = Math.Atan2(origin.y - vector2.y, origin.x - vector2.x);

            return Math.Abs(theta1 - theta2) * 180 / Math.PI;
        }
    }
}


