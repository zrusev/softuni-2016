using System;
using System.Linq;
public class StartUp
{
    public static void Main()
    {
        var myStack = new Stack<string>();

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] tokens = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];

            if (command == "Push")
            {
                foreach (var item in tokens.Skip(1))
                {
                    myStack.Push(item);
                }
            }
            else if (command == "Pop")
            {
                try
                {
                    myStack.Pop();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            input = Console.ReadLine();
        }

        PrintStackElements(myStack);
        PrintStackElements(myStack);
    }

    private static void PrintStackElements<T>(Stack<T> stack)
    {
        foreach (T item in stack)
        {
            Console.WriteLine(item);
        }

    }
}
