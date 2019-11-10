namespace SearchPathApi
{
    public interface XYLocation
    {
        int x { get; set; }
        int y { get; set; }
        XYLocation offset(int dx, int dy);
    }

    public static class XYLocationExtensions
    {
        public static bool equals(XYLocation a, XYLocation b)
        {
            return a.x == b.x && a.y == b.y;
        }
    }
}