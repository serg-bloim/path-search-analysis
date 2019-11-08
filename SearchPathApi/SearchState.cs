using System;

namespace SearchPathApi
{
    [Flags]
    public enum SearchState
    {
        NONE = 0,
        FINISHED = 0b1,
        FOUND = 0b10,
        OPTIMAL = 0b100
    }
}