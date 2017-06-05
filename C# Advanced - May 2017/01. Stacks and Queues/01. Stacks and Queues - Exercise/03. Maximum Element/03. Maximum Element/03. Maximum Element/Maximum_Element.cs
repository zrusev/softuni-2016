using System.Linq;

namespace _03.Maximum_Element
{
    using System;
    using System.Collections.Generic;
    public class Maximum_Element
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < input; i++)
            {
                int[] temp = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (temp[0])
                {
                    case 1:
                        stack.Push(temp[1]);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        Console.WriteLine(stack.Max());
                        break;
                }
            }
        }
    }
}
