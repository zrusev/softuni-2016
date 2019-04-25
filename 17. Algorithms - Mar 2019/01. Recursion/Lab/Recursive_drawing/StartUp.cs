namespace Recursive_drawing
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = 5;
            Print(n);
        }

        public static void Print(int n)
        {
            if (n <= 0)
            {
                return;
            }
            else
            {
                Console.WriteLine(new string('*', n));
                Print(n - 1);
                Console.WriteLine(new string('#', n));
            }
        }
    }
}
