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

        public static Point operator -(Point a, Point b)
        {
            return new Point { x = a.x - b.x, y = a.y - b.y };
        }

        public Point left()
        {
            return new Point { x = x - 1, y = y };
        }
        public Point right()
        {
            return new Point { x = x + 1, y = y };
        }
        public Point up()
        {
            return new Point { x = x, y = y-1 };
        }
        public Point down()
        {
            return new Point { x = x, y = y+1 };
        }
        public override string ToString()
        {
            return "Point("+x+","+y+")";
        }
    }
}
