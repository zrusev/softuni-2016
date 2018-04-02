using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        List<int> stones = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Lake lake = new Lake(stones);

        StringBuilder sb = new StringBuilder();

        foreach (int stone in lake)
        {
            sb.Append(stone + ", ");
        }

        string result = sb.ToString().Trim();
        result = result.Remove(result.Length - 1, 1);

        Console.WriteLine(result);
    }
}