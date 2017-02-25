namespace _03.Circles_Intersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Circles_Intersection
    {
        static void Main()
        {

            var firstCirleInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var secondCircleInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point firstCenter = new Point(firstCirleInput[0], firstCirleInput[1]);
            Point secondCenter = new Point(secondCircleInput[0], secondCircleInput[1]);

            Circle firstCircle = new Circle(firstCenter, firstCirleInput[2]);
            Circle secondCircle = new Circle(secondCenter, secondCircleInput[2]);

            if (Circle.Intersect(firstCircle, secondCircle))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
