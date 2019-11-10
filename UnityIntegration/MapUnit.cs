using System;
using System.Security.Cryptography.X509Certificates;

public class MapUnit
{
    public Interaction Interaction = new Interaction();
}

public class Interaction
{
    public static Func<int, int, bool> walkChecker;
    public static int width;
    public static int height;

    public bool CheckWalkableForUnit(int toX, int toY, bool staticOnly)
    {
        return walkChecker.Invoke(toX, toY);
    }
}