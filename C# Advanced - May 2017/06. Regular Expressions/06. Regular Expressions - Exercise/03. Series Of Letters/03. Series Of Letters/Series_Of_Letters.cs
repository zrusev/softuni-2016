using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Series_Of_Letters
{
    public class Series_Of_Letters
    {
        public static void Main()
        {

            var input = Console.ReadLine();
            Console.WriteLine(Regex.Replace(input, "([A-Za-z])\\1+", "$1"));

            //var input = Console.ReadLine();
            //    var pattern = @"([A-Za-z])\1+";
            //    var regex = new Regex(pattern);

            //foreach (Match match in regex.Matches(input))
            //{

            //    var part = match.Value.Substring(0, 1);
            //    input = input.Replace(match.Value, part);
            //}

            //Console.WriteLine(input);
        }
    }
}
