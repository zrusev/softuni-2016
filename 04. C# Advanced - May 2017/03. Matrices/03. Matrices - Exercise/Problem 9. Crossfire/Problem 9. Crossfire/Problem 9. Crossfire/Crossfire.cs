using System.Collections.Specialized;
using System.Linq;

namespace Problem_9.Crossfire
{
    using System;
    using System.Collections.Generic;
    public class Crossfire
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = FillMatrix(rows, cols);

            var command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                var commandTokens = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                var rowImpact = commandTokens[0];
                var colImpact = commandTokens[1];
                var radius = commandTokens[2];

                for (int rowIndex = rowImpact - radius; rowIndex <= rowImpact + radius; rowIndex++)
                {
                    if (IsInMatrix(rowIndex, colImpact, matrix))
                    {
                        matrix[rowIndex][colImpact] = -1;
                    }
                }

                for (int colIndex = colImpact - radius; colIndex <= colImpact + radius; colIndex++)
                {
                    if (IsInMatrix(rowImpact, colIndex, matrix))
                    {
                        matrix[rowImpact][colIndex] = -1;
                    }
                }

                FilterMatrix(matrix);

                command = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        private static void FilterMatrix(List<List<int>> matrix)
        {
            for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
            {
                for (int colIndex = matrix[rowIndex].Count - 1; colIndex >= 0; colIndex--)
                {
                    if (matrix[rowIndex][colIndex] == -1)
                    {
                        matrix[rowIndex].RemoveAt(colIndex);
                    }
                }
                if (matrix[rowIndex].Count == 0)
                {
                    matrix.RemoveAt(rowIndex);
                }
            }
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
            {
                Console.WriteLine(string.Join(" ", matrix[rowIndex]));
            }
        }

        private static bool IsInMatrix(int currentRow, int currentCol, List<List<int>> matrix)
        {
            if (currentRow >= 0 && currentRow < matrix.Count && currentCol >= 0 && currentCol < matrix[currentRow].Count )
            {
                return true;
            }

            return false;
        }

        private static List<List<int>> FillMatrix(int rows, int cols)
        {
            var matrix = new List<List<int>>();
            var counter = 1;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix.Add(new List<int>());
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex].Add(counter);
                    counter++;
                }
            }
            return matrix;
        }
    }
}
