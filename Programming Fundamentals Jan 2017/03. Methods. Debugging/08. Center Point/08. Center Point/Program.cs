using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Center_Point
{
    class Program
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            GetClosedPointToZero(x1, y1, x2, y2);
        }

        private static void GetClosedPointToZero(double x1, double y1, double x2, double y2)
        {
            double c1 = Math.Abs(Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2)));//c^2 = a^2 +b^2
            double c2 = Math.Abs(Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2)));// no work with or without Math.Abs
            if (c2 < c1)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");
            }
        }
    }
}