using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Filter_Stud_Phone
{
    class Filter_Stud_Phone
    {
        static void Main(string[] args)
        {
            var list = new List<string[]>();
            var input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                list.Add(tokens);

                input = Console.ReadLine();
            }

            list
                .Where(x => x[2].StartsWith("02") || x[2].StartsWith("+3592")).ToList().ForEach(w => Console.WriteLine($"{w[0]} {w[1]}"));
        }
    }
}
