using System.Linq;
using System.Text;

namespace Problem_4.Maximal_Sum
{
    using System;
    using System.Collections.Generic;
    public class Maximal_Sum
    {
        public static void Main()
        {
            var dimentions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrix = new int[dimentions[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
            
            var dict = new Dictionary<int, List<int>>();

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    var sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] + matrix[row + 1][col] +
                              matrix[row + 2][col] + matrix[row + 1][col + 1] + matrix[row + 2][col + 2] + matrix[row + 1][col + 2] + matrix[row + 2][col + 1];
                    var list = new List<int>() {matrix[row][col],  matrix[row][col + 1],  matrix[row][col + 2],
                                                matrix[row + 1][col], matrix[row + 1][col + 1], matrix[row + 1][col + 2],
                                                matrix[row + 2][col],  matrix[row + 2][col + 1], matrix[row + 2][col + 2]};
                    if (!dict.ContainsKey(sum))
                    {
                        dict.Add(sum, list);
                    }
                    
                }
            }

            var result = dict.Where(x => x.Key == dict.Keys.Max()).ToList();

            Console.WriteLine($"Sum = {result[0].Key}");

            var counter = 1;
            foreach (var row in result[0].Value)
            {
                Console.Write(row + " ");
                if (counter % 3 == 0)
                {
                    Console.WriteLine();
                }
                counter++;
            }

        }
    }
}
