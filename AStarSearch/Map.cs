using System;
using SearchPathApi;

namespace Algo
{
    public sealed class Map<T>
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

        public void Foreach(Action<int, int, T> callback)
        {
            for(int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    callback.Invoke(x, y, map[x, y]);
                }
            }
        }
    }
}