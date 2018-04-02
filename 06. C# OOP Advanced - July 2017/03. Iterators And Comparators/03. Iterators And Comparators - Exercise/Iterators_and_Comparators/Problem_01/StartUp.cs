using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string[] tokens = input.Split();

        ListyIterator<string> listyIterator = new ListyIterator<string>(tokens.Skip(1).ToList());

        while (input  != "END")
        {
            tokens = input.Split();

            string command = tokens[0];

            switch (command)
            {
                case "HasNext":
                    Console.WriteLine(listyIterator.HasNext());
                    break;
                case "Move":
                    Console.WriteLine(listyIterator.Move());
                    break;
                case "Print":
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    break;
            }

            input = Console.ReadLine();
        }
    }
}