using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Match_Full_Name
{
    public class Match_Full_Name
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            while (!input.Equals("END", StringComparison.InvariantCultureIgnoreCase))
            {
                var pattern = @"\b[A-Z][a-z]{1,}\s{1}[A-Z][a-z]{1,}\b";
                var regex = new Regex(pattern);

                foreach (var match in regex.Matches(input))
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}
