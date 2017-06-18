using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MultiplyNum
{
    public class MultiplyNum
    {
        public static void Main()
        {
            string numOne = Console.ReadLine().TrimStart('0', ' ', '\n', '\t');
            string numTest = Console.ReadLine();
            var numTwo = 0;

            if (int.Parse(numTest) == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else
            {
                numTwo = int.Parse(numTest.TrimStart('0', ' ', '\n', '\t'));
            }

            int[] numOneArray = ConvertToDigitArray(numOne);

            Console.WriteLine(Calculate(numOneArray, numTwo));

            Console.ReadLine();
        }

        public static int[] ConvertToDigitArray(string num)
        {
            char[] temp = num.ToCharArray();
            int[] tempInt = num.Select(x => int.Parse(Convert.ToString(x))).ToArray();
            tempInt = tempInt.Reverse().ToArray();
            return tempInt;
        }

        public static string Calculate(int[] a, int numTwo)
        {

            int carryOver = 0;
            List<string> result = new List<string>();

            for (int i = 0; i < a.Length; i++)
            {
                result.Add(Convert.ToString((a[i] * numTwo + carryOver) % 10));
                carryOver = (a[i] * numTwo + carryOver) / 10;

            }

            if (carryOver > 0)
            {
                result.Add(Convert.ToString(carryOver));
            }
            result.Reverse();
            string strResult = string.Join("", result);
            return strResult;
        }
    }
}