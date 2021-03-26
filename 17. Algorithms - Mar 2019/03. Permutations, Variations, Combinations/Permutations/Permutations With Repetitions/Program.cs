namespace Permutations_With_Repetitions
{
    using System;
    using System.Collections.Generic;

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
                HashSet<int> swapped = new HashSet<int>();

                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
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