using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> Printer = n => Console.WriteLine(n);

            var input = Console.ReadLine();
            input
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)                
                .ToList()
                .ForEach(Printer);            
        }
    }
}
