using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.Extract_Email
{
    public class Extract_Email
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var list = new List<string>();


            var pattern = @"(?<=\s)[A-Za-z0-9]+[.|\-|_]?[A-Za-z0-9]+@[A-Za-z]+-?[A-Za-z]+(\.[A-Za-z]+){1,2}";
            var regex = new Regex(pattern);

            foreach (Match match in regex.Matches(input))
            {
                list.Add(match.Value);
            }
            
            foreach (var l in list)
            {
                Console.WriteLine(l);
            }

        }
    }
}
