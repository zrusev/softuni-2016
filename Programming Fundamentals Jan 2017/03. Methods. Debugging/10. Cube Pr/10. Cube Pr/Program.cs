using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Cube_Pr
{
    class Program
    {
        static void Main()
        {
            double s = double.Parse(Console.ReadLine());
            string param = Console.ReadLine();

            switch (param)
            {
                case "face":
                    Console.WriteLine("{0:F2}", SSqrl(SPow(s, 2) * 2));
                    break;

                case "space":
                    Console.WriteLine("{0:F2}", SSqrl(SPow(s, 2) * 3));
                    break;

                case "volume":
                    Console.WriteLine("{0:F2}", SPow(s, 3));
                    break;

                case "area":
                    Console.WriteLine("{0:F2}", SPow(s, 2) * 6);
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
    