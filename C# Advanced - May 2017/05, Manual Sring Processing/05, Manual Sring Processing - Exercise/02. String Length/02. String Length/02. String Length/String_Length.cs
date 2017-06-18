using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.String_Length
{
    public class String_Length
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            if (input.Length <= 20)
            {
                Console.WriteLine(input.PadRight(20, '*'));
            }
            else
            {
                Console.WriteLine(input.Substring(0,20));
            }
        }
    }
}
