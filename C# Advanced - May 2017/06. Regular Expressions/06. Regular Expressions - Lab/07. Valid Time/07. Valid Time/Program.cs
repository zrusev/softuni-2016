using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.Valid_Time
{
    class Program
    {
        static void Main(string[] args)
        {

            var text = Console.ReadLine();

            while (!text.Equals("END"))
            {

                Regex regex = new Regex(@"^([01][0-9]):([012345][0-9]):([012345][0-9]) [AP]M$");

                if (regex.IsMatch(text))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                text = Console.ReadLine();
            }

        }
    }
}
