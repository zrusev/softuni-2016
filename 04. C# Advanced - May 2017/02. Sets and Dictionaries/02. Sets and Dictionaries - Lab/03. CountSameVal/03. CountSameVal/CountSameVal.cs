namespace _03.CountSameVal
{
    using System;
    using System.Collections.Generic;
    public class CountSameVal
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var inputTokens = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

            var dict = new SortedDictionary<double, int>();

            foreach (var token in inputTokens)
            {
                double reminder;
                if (token.Contains(","))
                {
                    reminder = double.Parse(token.Replace(",", "."));
                }
                else
                {
                    reminder = double.Parse(token);
                }
                

                if (!dict.ContainsKey(reminder))
                {
                    dict.Add(reminder, 1);
                }
                else
                {
                    dict[reminder]++;
                }

            }

            foreach (var pair in dict)
            {
                if (pair.Key.ToString().Contains("."))
                {

                    var reminder = pair.Key.ToString().Replace(".", ",");
                    Console.WriteLine($"{reminder} - {pair.Value} times");
                }
                else
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value} times");
                }
            }

        }
    }
}
