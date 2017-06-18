using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Non_Digit_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"[^\d]");

            Console.WriteLine($"Non-digits: {regex.Matches(text).Count}");
        }
    }
}
