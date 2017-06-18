using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> IsOdd = n => n % 2 == 0;

            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var odds = new List<int>();
            var evens = new List<int>();

            for (int index = 0; index < numbers.Count; index++)
            {
                switch (IsOdd(numbers[index]))
                {
                    case true:odds.Add(numbers[index]);
                        break;
                    case false:evens.Add(numbers[index]);
                        break;
                }
            }
            odds.Sort((a, b) => a.CompareTo(b));
            evens.Sort((a,b) => a.CompareTo(b));
            odds.AddRange(evens);

            Console.WriteLine(string.Join(" ", odds));
        }
    }
}
