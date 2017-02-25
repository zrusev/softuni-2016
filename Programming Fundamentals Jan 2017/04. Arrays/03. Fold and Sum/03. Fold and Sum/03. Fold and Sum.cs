namespace _03.Fold_and_Sum
{
    using System;
    using System.Linq;

    public class Methods
    {
        public static void Main()
        {

            string[] input = Console.ReadLine().Split(' ');
            int[] parsedNumbers = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                parsedNumbers[i] = int.Parse(input[i]);
            }

            var k = input.Length / 4;
            int[] firstRow = new int[parsedNumbers.Length - (2 * k)];
            int position = 0;
            for (int i = k - 1; i >= 0; i--)
            {
                firstRow[position] = parsedNumbers[i];
                position++;
                firstRow[firstRow.Length - i - 1] = parsedNumbers[parsedNumbers.Length - position];
            }

            int[] secondRow = new int[firstRow.Length];

            for (int i = 0; i <= firstRow.Length - 1; i++)
            {
                secondRow[i] = parsedNumbers[k + i];
            }

            int[] sum = new int[firstRow.Length];

            for (int i = 0; i <= firstRow.Length - 1; i++)
            {
                sum[i] = firstRow[i] + secondRow[i];
            }
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
