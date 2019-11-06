using System;

namespace Algo
{
    public struct Cell
    {
        public const int START = unchecked((int)0xFFFF0000);
        public const int DESTINATION = unchecked((int)0xFF00FF00);
        public static readonly Cell FREE = new Cell { val = unchecked((int)0xFFFFFFFF) };
        private int val;

        public bool isStart { get { return val == START; } }
        public bool isDest { get { return val == DESTINATION; } }
        public bool isWalkable { get { return val == FREE.val; } }

        public static Cell fromInt(int v)
        {
            return new Cell { val = v };
        }
    }
}