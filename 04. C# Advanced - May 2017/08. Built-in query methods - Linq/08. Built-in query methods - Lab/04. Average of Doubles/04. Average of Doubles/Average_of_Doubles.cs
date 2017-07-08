using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Average_of_Doubles
{
    class Average_of_Doubles
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine();

            Console.WriteLine("{0:f2}",names.Split(' ').Select(double.Parse).Average());
        }
    }
}
