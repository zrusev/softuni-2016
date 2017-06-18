using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Str
{
    public class Reverse_Str
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var sb = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }
            Console.WriteLine(sb);

        }
    }
}
