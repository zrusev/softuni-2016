using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _02.Base_N_to_base_10
{
    class Base_N_to_base_10
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            string number = input[1].ToString();
            BigInteger n = 1;
            BigInteger r = 0;

            for (int i = number.Length - 1; i >= 0; --i)
            {
                r += n * (number[i] - '0');
                n *= int.Parse(input[0]);
            }
            Console.WriteLine(r);
        }
    }
}