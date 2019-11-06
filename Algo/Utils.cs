using System;

namespace Algo
{
    public class Utils
    {
        public static int diff(int a, int b)
        {
            int res = a - b;
            if (res < 0)
            {
                res = -res;
            }
            return res;
        }
    }
    [Flags]
    public enum IterStatus
    {
        NONE = 0,
        FINISHED = 0b1,
        FOUND = 0b10,
        OPTIMAL = 0b100
    }
    [Flags]
    public enum CellFlags
    {
        TOP = 0b1,
        LEFT = 0b10,
        VISITED = 0b100,
        FRONTIER = 0b1000,
        START = 0b10000,
        END = 0b100000,
    }
}