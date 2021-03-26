namespace Variations
{
    using System;

    public class Program
    {
        private static int[] elements;
        private static bool[] used;
        private static int[] variations;

        private static void Variate(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    //if (!used[i])
                    //{
                        used[i] = true;
                        variations[index] = elements[i];

                        Variate(index + 1);

                        used[i] = false;
                    //}
                }
            }    
        }

        public static void Main()
        {
            elements = new int[] { 1, 2, 3, 4 };
            variations = new int[2];
            used = new bool[elements.Length];
            Variate(0);
        }
    }
}
