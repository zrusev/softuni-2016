using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Extract_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"\d+");

            if (!regex.IsMatch(text))
            {                
                return;
            }

            foreach (var reg in regex.Matches(text))
            {
                Console.WriteLine(reg);
            }            
        }
    }
}
