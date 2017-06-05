namespace Problem_7.Lego_Blocks
{
using System;
using System.Collections.Generic;
using System.Linq;
    public class Lego_Blocks
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            
            var matrix1 = new int[input][];

            for (int row = 0; row < input; row++)
            {
                matrix1[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                
            }

            var matrix2 = new int[input][];
            for (int row = 0; row < input; row++)
            {
                matrix2[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Reverse()
                    .Select(int.Parse).ToArray();

            }

            var matrixLenght = matrix1[0].Length + matrix2[0].Length;

            var matrix3 = new int[input][];

            for (int rowIndex = 0; rowIndex < input; rowIndex++)
            {
                matrix3[rowIndex] = matrix1[rowIndex].Concat(matrix2[rowIndex]).ToArray();
            }

            var cells = 0;
            var flag = false;
            for (int row = 0; row < matrix3.Length; row++)
            {
                if (matrix3[row].Length == matrixLenght)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

                cells += matrix3[row].Length;
            }


            if (flag == true)
            {
                for (int row = 0; row < matrix3.Length; row++)
                {
                    Console.WriteLine($"[{string.Join(", ", matrix3[row])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {cells}");
            }
        }
    }
}
