using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Vowel_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex regex = new Regex("[AEIOUYaeiouy]");

            Console.WriteLine($"Vowels: {regex.Matches(text).Count}");

        }
    }
}
