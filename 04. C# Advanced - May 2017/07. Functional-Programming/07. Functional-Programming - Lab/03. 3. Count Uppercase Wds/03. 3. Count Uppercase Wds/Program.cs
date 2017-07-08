using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._3.Count_Uppercase_Wds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => n[0] < 95)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
         }
    }
}
