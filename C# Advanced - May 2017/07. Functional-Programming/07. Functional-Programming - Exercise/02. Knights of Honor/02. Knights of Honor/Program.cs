using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> Printer = n => Console.WriteLine($"Sir {n}");

            var input = Console.ReadLine();
            input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(Printer);
        }
    }
}
