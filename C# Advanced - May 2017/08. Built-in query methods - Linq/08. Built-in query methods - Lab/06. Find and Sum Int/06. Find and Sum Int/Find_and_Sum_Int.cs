using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Find_and_Sum_Int
{
    class Find_and_Sum_Int
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var sum = input
                .Split(' ')
                .Select(w =>
                {
                    long value;
                    bool success = long.TryParse(w, out value);
                    return new {value, success};
                })
                .Where(s => s.success)
                .Select(n => n.value)
                .ToList()
                .Sum();

            if (sum != 0)
            {
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
