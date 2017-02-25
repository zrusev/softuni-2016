using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());


            Console.WriteLine(2 * (l + m));
            Console.WriteLine(l * m);
            Console.WriteLine(Math.Sqrt(l * l + m * m));

        }
    }
}
