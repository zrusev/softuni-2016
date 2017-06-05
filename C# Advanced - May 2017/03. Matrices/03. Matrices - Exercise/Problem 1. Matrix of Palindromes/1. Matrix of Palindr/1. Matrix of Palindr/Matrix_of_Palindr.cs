using System.Linq;
using System.Text;

namespace _1.Matrix_of_Palindr
{
    using System;
    using System.Collections.Generic;
    public class Matrix_of_Palindr
    {
        public static void Main()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var dimentions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrix = new string[dimentions[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                var list = new List<string>();
                for (int col = 0; col < dimentions[1]; col++)
                {

                    list.Add(string.Concat(alphabet[row], alphabet[row + col], alphabet[row]));
                }

                matrix[row] = list.ToArray();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }
    }
}
