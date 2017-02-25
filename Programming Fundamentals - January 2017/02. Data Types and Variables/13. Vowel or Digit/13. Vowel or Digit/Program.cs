using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {

            char input = char.Parse(Console.ReadLine());

            if (input > 47 && input < 58)
            {
                Console.WriteLine("digit");
            }
            else if (input == 97 || input == 101 || input == 105 || input == 111 || input == 117 || input == 121)
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }


        }
    }
}