using System;

namespace SearchPathApi
{
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
    
    public static class Extensions
    {
        public static bool ContainsFlag(this CellFlags flags, CellFlags flag)
        {
            return (flags & flag) != 0;
        }
        public static bool ContainsFlag(this IterStatus flags, IterStatus flag)
        {
            return (flags & flag) != 0;
        }
    }
    
}