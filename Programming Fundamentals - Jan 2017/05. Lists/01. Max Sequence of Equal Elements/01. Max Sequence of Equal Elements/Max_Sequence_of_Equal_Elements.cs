namespace _01.Max_Sequence_of_Equal_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Max_Sequence_of_Equal_Elements
    {
        static void Main()
        {

            string[] inputNumbers = Console.ReadLine().Split();

            int[] parsedNumbers = new int[inputNumbers.Length];

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                parsedNumbers[i] = int.Parse(inputNumbers[i]);
            }

            List<int> longestSubsquence = new List<int>();
            List<int> currentSubsquence = new List<int>();

            currentSubsquence.Add(parsedNumbers[0]);

            for (int i = 1; i < parsedNumbers.Length; i++)
            {
                if (parsedNumbers[i] == currentSubsquence[0])
                {
                    currentSubsquence.Add(parsedNumbers[i]);
                }
                else
                {
                    if (currentSubsquence.Count > longestSubsquence.Count)
                    {
                        longestSubsquence = new List<int>();
                        for (int j = 0; j < currentSubsquence.Count; j++)
                        {
                            longestSubsquence.Add(currentSubsquence[j]);
                        }
                    }
                    currentSubsquence = new List<int>();
                    currentSubsquence.Add(parsedNumbers[i]);
                }

            }

            if (currentSubsquence.Count > longestSubsquence.Count)
            {
                longestSubsquence = new List<int>();
                for (int j = 0; j < currentSubsquence.Count; j++)
                {
                    longestSubsquence.Add(currentSubsquence[j]);
                }
            }

            Console.WriteLine(string.Join(" ", longestSubsquence));

        }
    }
}
