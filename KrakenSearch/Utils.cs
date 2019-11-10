using System.Collections.Generic;

namespace System.MapLogic.KrakenSearch
{
    public struct Region
    {
        internal Point lower;
        internal Point upper;

        public bool contains(Point p)
        {
            return p >= lower && p <= upper;
        }
    }

    [Flags]
    public enum SearchState
    {
        NONE = 0,
        FINISHED = 0b1,
        FOUND = 0b10,
        OPTIMAL = 0b100
    }

    [Flags]
    public enum CellFlags
    {
        NONE       = 0b0,
        VISITED    = 0b1,
        FRONTIER   = 0b10,
        START      = 0b100,
        LEFT       = 0b1000,
        RIGHT      = 0b10000,
        UP         = 0b100000,
        DOWN       = 0b1000000,
    }

    [Flags]
    public enum IterStatus
    {
        NONE = 0,
        FINISHED = 0b1,
        FOUND = 0b10,
        OPTIMAL = 0b100
    }

    public static class Utils
    {
        public static int min(int a, int b) => a < b ? a : b;

        public static int max(int a, int b) => a > b ? a : b;

        public static List<Vector2i> toVectors(List<Point> path)
        {
            var list = new List<Vector2i>(path.Count);
            foreach (var p in path)
            {
                list.Add(new Vector2i(p.x, p.y));
            }

            return list;
        }

        public static CellFlags getDirection(Point @from, Point to)
        {
            CellFlags res = CellFlags.NONE;
            if (to.x > from.x) res |= CellFlags.RIGHT;
            if (to.x < from.x) res |= CellFlags.LEFT;
            if (to.y > from.y) res |= CellFlags.UP;
            if (to.y < from.y) res |= CellFlags.DOWN;
            return  res;
        }

        public static Point followBackwards(Point p, CellFlags flags)
        {
            Point res = p;
            if (flags.ContainsFlag(CellFlags.RIGHT)) res.x--;
            if (flags.ContainsFlag(CellFlags.LEFT)) res.x++;
            if (flags.ContainsFlag(CellFlags.UP)) res.y--;
            if (flags.ContainsFlag(CellFlags.DOWN)) res.y++;
            return res;
        }
    }
        
    public static class Extensions
    {
        public static bool ContainsFlag(this CellFlags flags, CellFlags flag)
        {
            return (flags & flag) != 0;
        }
        public static bool ContainsFlag(this SearchState flags, SearchState flag)
        {
            return (flags & flag) != 0;
        }
    }
}