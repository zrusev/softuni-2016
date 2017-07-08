using System;
using System.Linq;


namespace _04.Numbers_in_R
{
    class Program
    {
        static void Main()
        {
            double d = double.Parse(Console.ReadLine());
            Console.WriteLine(ReverseNumber(d));
        }

        static double ReverseNumber(double number)
        {
            return double.Parse(ReverseString(number.ToString()));
        }

        static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
