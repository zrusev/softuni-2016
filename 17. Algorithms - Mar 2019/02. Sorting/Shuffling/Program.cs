namespace Shuffling
{
    using System;
    
    public class Program
    {
        static int[] collection = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static void Main()
        {
            Console.WriteLine(Shuffle());
        }

        public static string Shuffle()
        {
            int[] numbers = new int[collection.Length];
            collection.CopyTo(numbers, 0);

            Random rnd = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                int r = i + rnd.Next(0, numbers.Length - i);

                int temp = numbers[i];
                numbers[i] = numbers[r];
                numbers[r] = temp;
            }

            return string.Join(", ", numbers);
        }
    }
}
