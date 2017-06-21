using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Take_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            numbers.Where(n => 10 <= n && n <= 20)
                .Distinct()
                .Take(2)
                .ToList()
                .ForEach(n => Console.Write(n + " "));
        }
    }
}
