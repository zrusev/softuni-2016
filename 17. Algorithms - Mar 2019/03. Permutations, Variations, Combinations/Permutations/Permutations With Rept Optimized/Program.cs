namespace Permutations_With_Rept_Optimized
{
    using System;

    public class Program
    {
        private static void Permute(int[] elements, int start, int end)
        {
            Print(elements);

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (elements[left] != elements[right])
                    {
                        Swap(elements, left, right);
                        Permute(elements, left + 1, end);
                    }
                }

                var firstElement = elements[left];
                for (int i = left; i <= end - 1; i++)
                {
                    elements[i] = elements[i + 1];
                }
                
                elements[end] = firstElement;
            }
        }
        
        private static void Print(int[] elements)
            => Console.WriteLine(string.Join(" ", elements));

        private static void Swap(int[] elements, int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        public static void Main()
        {
            var elements = new int[] { 3, 5, 1, 5, 5 };
            Array.Sort(elements);
            
            Permute(elements, 0, elements.Length - 1);
        }
    }
}