using System.Linq;

namespace _02.Sets_Of_Elem
{
    using System;
    using System.Collections.Generic;
    public class Sets_Of_Elem
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Trim()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();

            for (int i = 0; i < input[0]; i++)
            {
                var line = int.Parse(Console.ReadLine());

                if (!set1.Contains(line))
                {
                    set1.Add(line);
                }
            }

            for (int i = 0; i < input[1]; i++)
            {
                var line2 = int.Parse(Console.ReadLine());

                if (!set2.Contains(line2))
                {
                    set2.Add(line2);
                }
            }


            foreach (var record in set1)
            {
                if (set2.Contains(record))
                {
                    Console.Write(record + " ");
                }
            }

        }
    }
}
