using System;

namespace Algo
{
    public struct Point
    {
        public int x, y;
        public static bool operator ==(Point a, Point b)
        {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

    }
}
