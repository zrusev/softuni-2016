namespace Permutations
{
    using System;

    public class Program
    {
        private static int[] elements;
        private static bool[] used;
        private static int[] permutations;

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        var currentNumber = elements[i];
                        used[i] = true;
                        permutations[index] = currentNumber;

                        Permute(index + 1);

                        used[i] = false;
                    }
                }
            }

        }
 
        public static void Main()
        {
            elements = new int[] { 1, 2, 3, 4 };
            used = new bool[elements.Length];
            permutations = new int[elements.Length];

            Permute(0);
        }
    }
}