using System.Linq;

namespace Problem_2.Diagonal_D
{
    using System;
    using System.Collections.Generic;
    public class Diagonal_D
    {
        public static void Main()
        {
            var dimentions = int.Parse(Console.ReadLine());
            var matrix = new int[dimentions][];
            var leftSum = 0;
            var rightSum = 0;

            var counter = 0;
            var counter2 = dimentions - 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                matrix[row] = input;

                leftSum += input[counter];
                rightSum += input[counter2];
                counter++;
                counter2--;
            }

            Console.WriteLine(Math.Abs(leftSum - rightSum));
        }
    }
}
