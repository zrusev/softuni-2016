using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Match_Phone_Number
{
    public class Match_Phone_Number
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            while (!input.Equals("END", StringComparison.InvariantCultureIgnoreCase))
            {
                var pattern = @"^\+359([\s|-])2\1\d{3}\1\d{4}$";
                var regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    Console.WriteLine(regex.Match(input));
                }

                input = Console.ReadLine();
            }
        }
    }
}
