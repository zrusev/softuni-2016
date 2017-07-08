using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<long, long, bool> CheckIt = (n, m) => n >= m;
            var num = long.Parse(Console.ReadLine());

            var line = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in line)
            {
                if (ReturnSum(word, CheckIt, num))
                {
                    Console.WriteLine(word);
                    return;
                }
            }

        }

        private static bool ReturnSum(string word, Func<long, long, bool> CheckIt, long num)
        {
            long sum = 0;
            bool result = false;
            for (int index = 0; index < word.Length; index++)
            {
                sum += word[index];
            }

            if (CheckIt(sum, num) == true)
            {
                result = true;
            }
            return result;
        }
    }
}
