using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {

            var text = Console.ReadLine();

            while (!text.Equals("END"))
            {

                Regex regex = new Regex(@"^[\w\d-]{3,16}$");

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
