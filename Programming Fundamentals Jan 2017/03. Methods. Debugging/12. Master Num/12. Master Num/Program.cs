using System;
using System.Linq;


namespace _12.Master_Num
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            for (int x = 1; x <= input; x++)
            {
                if (isPalindrome(x) && SumOfDigits(x) % 7 == 0 && EvenNumber(x))
                {
                    Console.WriteLine(x);
                }
            }


        }
        static bool isPalindrome(int x)
        {
            if (x < 0)
                return false;
            int div = 1;
            while (x / div >= 10)
            {
                div *= 10;
            }
            while (x != 0)
            {
                int l = x / div;
                int r = x % 10;
                if (l != r)
                    return false;
                x = (x % div) / 10;
                div /= 100;
            }
            return true;
        }
        static int SumOfDigits(int x)
        {
            var sum = 0;
            while (x != 0)
            {
                sum += x % 10;
                x /= 10;
            }
            return sum;
        }
        static bool EvenNumber(int x)
        {
            var result = false;
            while (x != 0)
            {
                if (x % 2 == 0) result = true;
                x /= 10;
            }
            return result;
        }

    }
}


