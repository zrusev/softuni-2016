using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Nature_s_Prophet
{
    class Nature_s_Prophet
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = FillMatrix(rows, cols);

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                var input = inputLine.Split(' ').Select(int.Parse).ToArray();
                var affectedRow = input[0];
                var affectedColumn = input[1];

                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix[i].Count; j++)
                    {
                        if (affectedColumn == j || affectedRow == i)
                        {
                            matrix[i][j]++;
                        }
                    }
                }
            }
            PrintMatrix(matrix);            
        }

        private static List<List<int>> FillMatrix(int rows, int cols)
        {
            var matrix = new List<List<int>>();
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix.Add(new List<int>());
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex].Add(0);
                }
            }
            return matrix;
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
            {
                Console.WriteLine(string.Join(" ", matrix[rowIndex]));
            }
        }
    }
}
