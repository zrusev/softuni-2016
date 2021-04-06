namespace Subsequence
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        // Longest Increasing Subsequence

        public static void Main()
        {
            var numbers = new int[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };

            var solutions = new int[numbers.Length];
            var prev = new int[numbers.Length];
            
            var maxSolution = 0;
            var maxSolutionIndex = 0;

            for (int current = 0; current < numbers.Length; current++)
            {
                var solution = 1;
                var prevIndex = -1;
                var currentNumber = numbers[current];

                for (int solIndex = 0; solIndex < current; solIndex++)
                {
                    var previousNumber = numbers[solIndex];
                    var previousSolution = solutions[solIndex];

                    if(currentNumber > previousNumber 
                        && solution <= previousSolution)
                    {
                        solution = previousSolution + 1;
                        prevIndex = solIndex;
                    }
                }
                
                solutions[current] = solution;
                prev[current] = prevIndex;

                if (solution > maxSolution)
                {
                    maxSolution = solution;
                    maxSolutionIndex = current;
                }
            }

            Console.WriteLine(maxSolution);

            var index = maxSolutionIndex;
            var result = new List<int>();

            while(index != -1)
            {
                var currentNumber = numbers[index];
                result.Add(currentNumber);
                index = prev[index];
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}