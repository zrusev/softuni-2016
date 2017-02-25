using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Primes
{
    class Program
    {
        static void Main()
        {

            var startNum = int.Parse(Console.ReadLine());
            var endNum = int.Parse(Console.ReadLine());

            var primesInRange = FindPrimesInRange(startNum, endNum);
            Console.WriteLine(string.Join(", ", primesInRange));
        }

        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            var primes = new List<int>();
            for (int currentNUm = startNum; currentNUm <= endNum; currentNUm++)
            {
                if (IsPrime(currentNUm))
                {
                    primes.Add(currentNUm);
                }
            }
            return primes;
        }

        private static bool IsPrime(long n)
        {
            var isPrime = true;

            if (n == 0 || n == 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }
    }
}

