namespace Nested_loops
{
    using System;
    public class StartUp
    {
        private static int[] loops;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            loops = new int[count];

            NestedLoops(0, count);
        }

        private static void NestedLoops(int current, int count)
        {
            if (current == count)
            {
                Print(loops);
                return;
            }

            for (int i = 1; i <= count; i++)
            {
                loops[current] = i;
                NestedLoops(count, current + 1);
            }
        }

        private static void Print(int[] loops)
        {
            Console.WriteLine(string.Join(" ", loops));
        }
    }
}
