using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Integer_to_Hex
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());
            string hexValue = input.ToString("X");
            Console.WriteLine(hexValue);
            string binary = Convert.ToString(input, 2);
            Console.WriteLine(binary);
        }
    }
}
