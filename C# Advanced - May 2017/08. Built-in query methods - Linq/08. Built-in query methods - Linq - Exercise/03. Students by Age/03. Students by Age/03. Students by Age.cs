using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Students_by_Age
{
    class Program
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

            var newlist = list.Where(x => 18 <= int.Parse(x[2]) & int.Parse(x[2]) <= 24).ToList();
            foreach (var l in newlist)
            {
                Console.WriteLine($"{l[0]} {l[1]} {l[2]}");
            }
        }
    }
}
