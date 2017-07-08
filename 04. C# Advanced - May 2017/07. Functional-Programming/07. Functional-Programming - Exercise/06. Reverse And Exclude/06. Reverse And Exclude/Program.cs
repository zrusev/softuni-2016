using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> Divisible = (n, m) => n % m != 0;

            var numbers = Console.ReadLine()
                .Split(new[] {' ', ',', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var dividor = int.Parse(Console.ReadLine());

            var selelected = numbers
                .Where(n => Divisible(n, dividor) == true)
                .Reverse();

            Console.WriteLine(string.Join(" ", selelected));
        }
    }
}
