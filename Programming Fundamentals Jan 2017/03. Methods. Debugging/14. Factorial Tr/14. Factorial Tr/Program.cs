using System;
using System.Linq;
using System.Numerics;

namespace _14.Factorial_Tr
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fact(n));

        }

        static int Fact(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return TrailingZeros(factorial);
        }

        static int TrailingZeros(BigInteger factorial)
        {
            int[] arr = factorial.ToString().Select(t => int.Parse(t.ToString())).ToArray();

            var counter = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == 0)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            return counter;
        }
    }
}

