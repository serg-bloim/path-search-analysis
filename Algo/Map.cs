﻿using System;

namespace Algo
{
    public class Map<T>
    {
        public readonly int width;
        public readonly int height;
        private T[,] map;

        public T this[int x, int y]
        {
            get { return map[x,y]; }
            set { map[x,y] = value; }
        }
        public T this[Point p]
        {
            get { return map[p.x,p.y]; }
            set { map[p.x,p.y] = value; }
        }

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            map = new T[width, height];
        }
    }
}