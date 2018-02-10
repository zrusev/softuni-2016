namespace Problem7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {' ', '\\', '/', '(', ')'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var pattern = @"^([a-zA-Z][a-zA-Z_\d]+)$";

            var list = new List<string>();

            foreach (var line in input)
            {
                if (Regex.IsMatch(line, pattern) && line.Length >= 3 && line.Length <= 25)
                {                    
                    list.Add(line);
                }
            }

            var first = string.Empty;
            var second = string.Empty;
            var maxSum = 0;

            for (int i = 1; i < list.Count; i++)
            {
                var sum = list.ElementAt(i - 1).Length + list.ElementAt(i).Length;

                if (sum > maxSum)
                {
                    maxSum = sum;
                    first = list.ElementAt(i - 1);
                    second = list.ElementAt(i);
                }
            }

            Console.WriteLine(first);
            Console.WriteLine(second);
        }
    }
}