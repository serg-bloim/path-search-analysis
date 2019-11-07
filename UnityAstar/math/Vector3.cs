namespace UnityAstar.math
{
    public class Vector3 : Vector2
    {
        internal int z;
        private int v1;
        private int v2;

        public Vector3():base(0,0)
        {
        }

        public Vector3(int v1, int v2):base(v1,v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}