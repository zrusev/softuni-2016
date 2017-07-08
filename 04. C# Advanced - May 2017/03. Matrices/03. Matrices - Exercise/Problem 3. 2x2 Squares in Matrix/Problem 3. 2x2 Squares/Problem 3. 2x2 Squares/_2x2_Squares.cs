using System.Linq;

namespace Problem_3._2x2_Squares
{
    using System;
    using System.Collections.Generic;
    public class _2x2_Squares
    {
        public static void Main()
        {
            var dimentions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrix = new char[dimentions[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
            }

            var counter = 0;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    var temp = matrix[row][col];

                    if(char.Equals(temp, matrix[row + 1][col]) && char.Equals(temp, matrix[row][col + 1]) && char.Equals(temp, matrix[row + 1][col + 1]))
                    {
                        counter++;
                    }
                }
                
            }
            Console.WriteLine(counter);  
        }
    }
}
