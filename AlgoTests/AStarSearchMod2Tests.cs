using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algo.Tests
{
    [TestClass()]
    public class AStarSearchMod2Tests
    {
        [TestMethod()]
        public void AngleBetweenTest()
        {
            Point p1 = Point.of(5, 5);
            Point p2 = Point.of(7, 7);
            Point p3 = Point.of(3,3);
            var angle = AStarSearchMod2.AngleBetween(p1, p2, p3);
            Console.WriteLine("{0}", angle);
        }
    }
}