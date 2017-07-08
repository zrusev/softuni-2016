using System;
using System.Linq;


namespace _05.Fibonacci
{
    class Program
    {
        static void Main()
        {

            int input = int.Parse(Console.ReadLine());

            Console.WriteLine(Fib(input));

        }
        static ulong Fib(int n)
        {
            double sqrt5 = Math.Sqrt(5);
            double p1 = (1 + sqrt5) / 2;
            double p2 = -1 * (p1 - 1);


            double n1 = Math.Pow(p1, n + 1);
            double n2 = Math.Pow(p2, n + 1);
            return (ulong)((n1 - n2) / sqrt5);
        }

    }
}
