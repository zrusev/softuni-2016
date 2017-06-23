using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _04._10_to_N
{
    public class _10_to_N
    {
        public static void Main()
        {
            string[] arguments = Console.ReadLine().Split();

            BigInteger toBase = BigInteger.Parse(arguments[0]);
            BigInteger number = BigInteger.Parse(arguments[1]);

            string parsedNum = string.Empty;

            do
            {
                parsedNum += number % toBase;
                number /= toBase;
            }
            while (number > 0);

            char[] toBeReversed = parsedNum.ToCharArray();
            Array.Reverse(toBeReversed);
            string result = string.Join(string.Empty, toBeReversed);

            Console.WriteLine(result);
        }

    }
}
