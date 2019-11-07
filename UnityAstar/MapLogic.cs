namespace UnityAstar
{
    internal class MapLogic
    {
        private static MapLogic _Instance;
        internal int Width;
        internal int Height;

        public static MapLogic Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new MapLogic();
                return _Instance;
            }
        }
    }
}