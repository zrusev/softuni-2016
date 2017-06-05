using System.Linq;
using System.Text;

namespace Problem_6.Target
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var dimentions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            char[] input = Console.ReadLine().ToCharArray();
            char[] word = new char[dimentions[0] * dimentions[1]];

            for (int i = 0; i < word.Length; i++)
            {
                word[i] = input[i % input.Length];
            }

            var matrix = new char[dimentions[0]][];

            var step = dimentions[0];
            var counter = word.Length - 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[dimentions[1]];
                if (step % 2 != 0)
                {
                    for (int col = 0; col < dimentions[1]; col++)
                    {
                        matrix[row][col] = word[counter];
                        counter--;
                    }
                }
                else
                {
                    for (int col = dimentions[1] - 1; col >= 0; col--)
                    {
                        matrix[row][col] = word[counter];
                        counter--;
                    }
                }
                step--;
            }

            //for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            //{
            //    matrix[rowIndex][dimentions[1] - 1] =
            //        char.Parse(matrix[rowIndex][dimentions[1] - 1].ToString().ToUpper());
            //}

            var shot = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int rowIndex = 0; rowIndex < dimentions[0]; rowIndex++)
            {
                for (int colIndex = 0; colIndex < dimentions[1]; colIndex++)
                {
                    if ((rowIndex - shot[0]) * (rowIndex - shot[0]) + (colIndex - shot[1]) * (colIndex - shot[1]) <= shot[2] * shot[2])
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
            }

            //for (int coIndex = 0; coIndex < dimentions[1]; coIndex++)
            //{
            //    char[] temp = new char[dimentions[0]];

            //    for (int rowsIndex = 0; rowsIndex < dimentions[0]; rowsIndex++)
            //    {
            //        temp[rowsIndex] = matrix[rowsIndex][coIndex];
            //    }

            //    temp = temp.OrderByDescending(x => x == ' ').ToArray();

            //    for (int rowsIndex = 0; rowsIndex < dimentions[0]; rowsIndex++)
            //    {
            //        matrix[rowsIndex][coIndex] = temp[rowsIndex];
            //    }
            //}

            //for (int col1 = 0; col1 < matrix.Length; col1++)
            //{
            //    for (int row = 0; row < matrix.Length - 1; row++)
            //    {
            //        for (int col = 0; col < matrix.Length; col++)
            //        {
            //            if (matrix[row + 1][col] == ' ')
            //            {
            //                matrix[row + 1][col] = matrix[row][col];
            //                matrix[row][col] = ' ';
            //            }
            //        }
            //    }
            //}

            //bool fallen = false;
            //do
            //{
            //    fallen = false;
            //    for (int row = 0; row < matrix.Length - 1; row++)
            //    {
            //        for (int col = 0; col < matrix.Length; col++)
            //        {
            //            if (matrix[row][col] != ' ' && matrix[row + 1][col] == ' ')
            //            {
            //                matrix[row + 1][col] = matrix[row][col];
            //                matrix[row][ col] = ' ';
            //                fallen = true;
            //            }
            //        }
            //    }
            //} while (fallen);

            for (int rowIndex = 0; rowIndex < dimentions[0]; rowIndex++)
            {
                for (int colIndex = 0; colIndex < dimentions[1]; colIndex++)
                {
                    Console.Write(matrix[rowIndex][colIndex]);
                }
                Console.WriteLine();
            }

        }
    }
}
