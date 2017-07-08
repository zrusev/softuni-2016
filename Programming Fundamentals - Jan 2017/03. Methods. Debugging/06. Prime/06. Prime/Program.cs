using System;
using System.Linq;


namespace _06.Prime
{
    class Program
    {
        static void Main()
        {
            long input = long.Parse(Console.ReadLine());
            if (input == 0)
            {
                Console.WriteLine("False");
            }
            else if (isPrime(input))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

        }
        public static bool isPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }


    }
}