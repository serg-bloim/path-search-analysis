namespace UnityAstar
{
    internal abstract class MapUnit
    {
        public abstract UnitInteraction Interaction { get; }
    }

    public interface UnitInteraction
    {
        bool CheckWalkableForUnit(int x, int y, bool staticLookup);
    }
}