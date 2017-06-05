namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;
    
    public static class MatchingBrackets
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    var startIndex = stack.Pop();
                    string reminder = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(reminder);
                }
            }

        }
    }
}
