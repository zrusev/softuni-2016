using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Bounded_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var bounds = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).Where(n => bounds.Min() <= n && n <= bounds.Max()).ToList();

            Console.Write(string.Join(" ", numbers));
        }
    }
}
