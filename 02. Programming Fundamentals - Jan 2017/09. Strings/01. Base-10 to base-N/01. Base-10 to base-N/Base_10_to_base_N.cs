using System;
using System.Numerics;

namespace _01.Base_10_to_base_N
{
    class Base_10_to_base_N
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            BigInteger decimalNumber = BigInteger.Parse(input[1]);
            long baseN = long.Parse(input[0]);

            BigInteger remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % baseN;
                decimalNumber /= baseN;
                result = remainder.ToString() + result;
            }
            Console.WriteLine(result);

        }
    }
}
