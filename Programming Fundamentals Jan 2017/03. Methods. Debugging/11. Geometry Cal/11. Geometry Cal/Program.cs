using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Geometry_Cal
{
    class Program
    {
        static void Main()
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "triangle":
                    //Console.WriteLine("{0:F2}",SSqrl(SPow(s, 2) * 2));
                    double side = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:F2}", (side * height) / 2);
                    break;

                case "square":
                    //Console.WriteLine("{0:F2}", SSqrl(SPow(s, 2) * 3));
                    double side2 = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:F2}", SPow(side2, 2));
                    break;

                case "rectangle":
                    //Console.WriteLine("{0:F2}", SPow(s, 3));
                    double widht = double.Parse(Console.ReadLine());
                    double height2 = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:F2}", widht * height2);
                    break;

                case "circle":
                    //Console.WriteLine("{0:F2}", SPow(s, 2) * 6);
                    double radius = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:F2}", Math.PI * SPow(radius, 2));
                    break;

            }
        }
        static double SPow(double s, double x)
        {
            return Math.Pow(s, x);
        }
        static double SSqrl(double s)
        {
            return Math.Sqrt(s);
        }

    }
}

