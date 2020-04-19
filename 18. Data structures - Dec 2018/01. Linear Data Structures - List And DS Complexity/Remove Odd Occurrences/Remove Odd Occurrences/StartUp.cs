namespace Remove_Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            //Print_Big_O_N_square(numbers);

            Print_Big_O_2N(numbers);
        }

        private static void Print_Big_O_2N(List<int> numbers)
        {
            Dictionary<int, int> ocurrencies = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!ocurrencies.ContainsKey(numbers[i]))
                {
                    ocurrencies.Add(numbers[i], 0);
                }

                ocurrencies[numbers[i]] += 1;
            }

            for (int i = 0; i < numbers.Count; i++)
            {

                if (ocurrencies[numbers[i]] % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }

        private static void Print_Big_O_N_square(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j] == numbers[i])
                    {
                        count++;
                    }
                }

                if (count % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}
