namespace Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Simple_Calculator
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var reminder = input.Split(' ');
            var stack = new Stack<string>(reminder.Reverse());

            while (stack.Count > 1)
            {
                var firstNumber = int.Parse(stack.Pop());
                var op = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());

                if (op == "+")
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
            
        }
    }
}
