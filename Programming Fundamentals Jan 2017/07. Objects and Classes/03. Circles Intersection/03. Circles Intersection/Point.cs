namespace _03.Circles_Intersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Point
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static int CalculateDistance(Point p1, Point p2)
        {
            return (int)Math.Sqrt(((p1.X - p2.X) * (p1.X - p2.X)) + ((p1.Y - p2.Y) * (p1.Y - p2.Y)));
        }

    }

}
