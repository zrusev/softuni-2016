using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int, int, bool> Len = (n, m) => n <= m ;

            var length = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine()
                .Split(new[] {' ', ',', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            numbers
                .Where(n => Len(n.Length, length) == true)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
