using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Excellent_Students
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

            list
                .Where(x => x.Skip(2).Any(n => int.Parse(n) == 6)).ToList().ForEach(w => Console.WriteLine($"{w[0]} {w[1]}"));
        }
    }
}
