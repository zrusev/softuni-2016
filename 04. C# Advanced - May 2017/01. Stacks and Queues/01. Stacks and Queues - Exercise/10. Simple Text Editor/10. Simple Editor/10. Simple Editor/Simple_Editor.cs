using System.Text;

namespace _10.Simple_Editor
{
    using System;
    using System.Collections.Generic;
    public class Simple_Editor
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            //string text = string.Empty;
            var stack = new Stack<string>();
            StringBuilder builder = new StringBuilder();


            for (int i = 0; i < n; i++)
            {
                string[] commmands = Console.ReadLine().Split();

                if (int.Parse(commmands[0]) == 1)
                {
                    stack.Push(builder.ToString());
                    builder.Append(commmands[1]);
                }

                if (int.Parse(commmands[0]) == 2)
                {
                    stack.Push(builder.ToString());
                    builder.Remove(builder.Length - int.Parse(commmands[1]), int.Parse(commmands[1]));
                }

                if (int.Parse(commmands[0]) == 3)
                {
                    Console.WriteLine(builder[int.Parse(commmands[1]) - 1]);
                }

                if (int.Parse(commmands[0]) == 4)
                {
                    builder = new StringBuilder();
                    builder.Append(stack.Pop());
                }
            }
        }
    }
}
