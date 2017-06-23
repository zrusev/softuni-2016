using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10.Unicode_Char
{
    public class Unicode_Char
    {
        public static void Main()
        {

            char[] originalString = Console.ReadLine().ToCharArray();
            StringBuilder asAscii = new StringBuilder();
            foreach (char c in originalString)
            {
                int cint = Convert.ToInt32(c);
                asAscii.Append(String.Format("\\u{0:x4} ", cint).Trim());
            }
            Console.WriteLine(string.Join(" ", asAscii));
        }
    }
}
