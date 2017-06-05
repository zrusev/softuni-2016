using System.Linq;

namespace HotPatato
{
    using System;
    using System.Collections.Generic;
    public static class HotPatato
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var number= int.Parse(Console.ReadLine());
            var queue = new Queue<string>(input.Split(' '));

            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }
                Console.WriteLine("Removed " + queue.Dequeue());
            }

            Console.WriteLine("Last is " + queue.Dequeue());
        }
    }
}
