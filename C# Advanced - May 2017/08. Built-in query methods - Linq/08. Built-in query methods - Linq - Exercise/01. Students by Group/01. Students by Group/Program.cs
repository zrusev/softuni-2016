using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students_by_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string[]>();
            var input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                var tokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                list.Add(tokens);
                
                input = Console.ReadLine();
            }

            var newlist = list.Where(x => int.Parse(x[2]) == 2).OrderBy(x => x[0]).ToList();
            foreach (var l in newlist)
            {
                Console.WriteLine($"{l[0]} {l[1]}");
            }
        }
    }
}
