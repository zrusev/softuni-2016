using System;
using System.Linq;
using System.Numerics;

namespace _13.Factorial
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fact(n));

        }

        static BigInteger Fact(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
