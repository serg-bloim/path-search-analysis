using System;

namespace Algo
{
    public class Map
    {
        public readonly int width;
        public readonly int height;
        private Cell[,] map;
        public Point startCell;
        public Point destCell;

        public Cell this[int x, int y]
        {
            get { return map[x,y]; }
            set { map[x,y] = value; }
        }
        public Cell this[Point p]
        {
            get { return map[p.x,p.y]; }
            set { map[p.x,p.y] = value; }
        }

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            map = new Cell[width, height];
        }

        public void finishInit()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var v = map[x, y];
                    if (v.isStart)
                    {
                        startCell.x = x;
                        startCell.y = y;
                    }
                    if (v.isDest)
                    {
                        destCell.x = x;
                        destCell.y = y;
                    }
                }
            }
        }
    }
}