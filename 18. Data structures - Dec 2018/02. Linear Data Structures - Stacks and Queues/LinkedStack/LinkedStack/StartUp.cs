namespace LinkedStack
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            stack.Push(5);
            stack.Push(5);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine(string.Join(", ", stack.ToArray()));
        }
    }
}
