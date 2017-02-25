using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');

            char[] char1 = new char[arr1.Length];
            char[] char2 = new char[arr2.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                char1[i] = char.Parse(arr1[i]);
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                char2[i] = char.Parse(arr2[i]);
            }

            var difference = 0;
            for (int i = 0; i < Math.Min(char1.Length, char2.Length); i++)
            {
                if (char1[i] == char2[i])
                {
                    difference = i + 1;
                }
            }

            if (difference == char1.Length && difference == char2.Length)
            {
                Console.WriteLine(string.Join("", char1));
                Console.WriteLine(string.Join("", char2));
            }
            else if (difference == char1.Length)
            {
                Console.WriteLine(string.Join("", char1));
                Console.WriteLine(string.Join("", char2));
            }
            else if (difference == char2.Length)
            {
                Console.WriteLine(string.Join("", char2));
                Console.WriteLine(string.Join("", char1));
            }
            else if (char1[0] > char2[0])
            {
                Console.WriteLine(string.Join("", char2));
                Console.WriteLine(string.Join("", char1));
            }
            else
            {
                Console.WriteLine(string.Join("", char1));
                Console.WriteLine(string.Join("", char2));
            }

        }
    }
}
