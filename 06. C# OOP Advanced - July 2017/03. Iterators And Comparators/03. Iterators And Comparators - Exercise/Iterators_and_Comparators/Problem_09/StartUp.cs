using System;
public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        LinkedList<int> linkedList = new LinkedList<int>();

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            string command = tokens[0];

            if (command == "Add")
            {
                linkedList.Add(int.Parse(tokens[1]));
            }
            else if (command == "Remove")
            {
                linkedList.Remove(int.Parse(tokens[1]));
            }
        }

        Console.WriteLine(linkedList.Count);

        foreach (int item in linkedList)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}