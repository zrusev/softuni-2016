using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Students_Enrolled
{
    class Students_Enrolled
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
                .Where(x => x[0].Substring(x[0].Length - 1, 1).Equals("4") || x[0].Substring(x[0].Length - 1, 1).Equals("5"))
                .ToList().ForEach(w => Console.WriteLine($"{w[1]} {w[2]} {w[3]} {w[4]}"));
        }
    }
}
