using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> IsDividor = (n, m) => n % m == 0;

            var num = int.Parse(Console.ReadLine());

            var dividors = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var answer = new List<int>();

            try
            {
            var key = true;
            for (int i = 1; i <= num; i++)
            {
                key = true;
                for (int j = 0; j < dividors.Length; j++)
                {                    
                    if (IsDividor(i, dividors[j]) == false)
                    {
                        key = false;
                        break;
                    }
                }

                if (key)
                {
                    answer.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", answer));

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Zero division!");
                //throw;
            }
        }
    }
}
