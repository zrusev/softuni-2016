namespace Egyptian_Fract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var number = Console.ReadLine().Split('/');

            var numerator = long.Parse(number[0]); // 43
            var denominator = long.Parse(number[1]); // 48

            if (denominator < numerator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            Console.Write($"{numerator}/{denominator} = ");

            var index = 2;
            var result = new List<int>();

            while (numerator != 0)
            {
                // 1 / 2
                var nextNumerator = numerator * index; // 43 * 2
                var indexNumerator = denominator; // 48 * 1

                var remaining = nextNumerator - indexNumerator; // 86 - 48

                if (remaining < 0)
                {
                    index++;
                    continue;
                }

                result.Add(index);

                numerator = remaining;
                denominator = denominator * index;

                index++;
            }

            Console.WriteLine(string.Join(" + ", result.Select(r => $"1/{r}")));
        }
    }
}
