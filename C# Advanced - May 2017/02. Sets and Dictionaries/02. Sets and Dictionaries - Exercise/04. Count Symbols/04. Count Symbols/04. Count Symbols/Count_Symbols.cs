namespace _04.Count_Symbols
{
    using System;
    using System.Collections.Generic;
    public class Count_Symbols
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var dict = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];

                if (!dict.ContainsKey(currentSymbol))
                {
                    dict[currentSymbol] = 0;
                }
                dict[currentSymbol]++;
            }

            foreach (var record in dict)
            {
                Console.WriteLine($"{record.Key}: {record.Value} time/s");
            }

        }
    }
}
