using System.Linq;

namespace _03.Periodic_Table
{
    using System;
    using System.Collections.Generic;
    public class Periodic_Table
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var set = new SortedSet<string>();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine()
                    .Trim()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    if (!set.Contains(input[j]))
                    {
                        set.Add(input[j]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", set));


        }
    }
}
