using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.Extract_Tags
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().Trim();

            while (!text.Equals("END"))
            {
                Regex regex = new Regex(@"<.*?>");

                foreach (var match in regex.Matches(text))
                {
                    Console.WriteLine(match);
                }

                text = Console.ReadLine();
            }


        }
    }
}
