using System.Linq;

namespace _04.Basic_Queue
{
    using System;
    using System.Collections.Generic;
    public class Basic_Queue
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                            .Trim()
                            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            
            var queue = new Queue<int>();

            int[] numbers = Console.ReadLine()
                            .Trim()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();


            for (int i = 0; i < input[0]; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < input[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
