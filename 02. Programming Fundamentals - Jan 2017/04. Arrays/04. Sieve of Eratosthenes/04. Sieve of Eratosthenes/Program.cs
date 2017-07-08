using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {

            long sum = 0;
            long n = long.Parse(Console.ReadLine());
            bool[] primes = new bool[n + 1];//by default they're all false
            for (int i = 2; i <= n; i++)
            {
                primes[i] = true;//set all numbers to true
            }
            primes[0] = primes[1] = false;
            //weed out the non primes by finding mutiples 
            for (int p = 2; p <= n; p++)
            {
                if (primes[p])//is true
                {
                    Console.Write(p + " ");

                    for (long j = 0; j < n; j++)
                    {
                        if (j * p <= n && j * p >= 0)
                        {
                            primes[j * p] = false;
                        }
                    }
                }
            }
            Console.WriteLine();

        }
    }
}
