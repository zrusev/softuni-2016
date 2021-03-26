namespace Permutations_Swap_Algorithm
{
    using System;

    public class Program
    {
        private static int[] elements;
        
        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                Permute(index + 1);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }

        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        public static void Main()
        {
            elements = new int[] { 1, 2, 3, 4 };

            Permute(0);
        }
    }
}