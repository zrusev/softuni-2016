using System.Collections;
using System.Data.Common;

namespace _05.Sequence_Queue
{
    using System;
    using System.Collections.Generic;
    public class Sequence_Queue
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var queue2 = new Queue<long>();

            queue.Enqueue(n);

            for (int i = 0; i < 50; i++)
            {
                 var reminder = queue.Dequeue();
                 queue2.Enqueue(reminder);

                 queue.Enqueue(reminder + 1);
                 queue.Enqueue(2 * reminder + 1);
                 queue.Enqueue(reminder + 2);
            }


            Console.WriteLine(string.Join(" ", queue2.ToArray()));

        }
    }
}
