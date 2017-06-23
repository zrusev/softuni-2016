namespace _01.Second_Nature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Second_Nature
    {
        public static void Main()
        {
            var flowStack = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray().Reverse());
            var watStack = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            var WTF = new Queue<int>();

            while (flowStack.Any() && watStack.Any())
            {
                int currFlower = flowStack.Pop();
                int currWat = watStack.Pop();

                if (currFlower == currWat)
                {
                    WTF.Enqueue(currFlower);
                }

                else if(currWat >= currFlower)
                {
                    int newWat = currWat - currFlower;
                    if (watStack.Count == 0)
                    {
                        watStack.Push(newWat);
                    }
                    else
                    {
                        int toAdd = watStack.Pop() + newWat;
                        watStack.Push(toAdd);
                    }
                }

                else
                {
                    flowStack.Push(currFlower - currWat);
                }
            }

            Console.WriteLine(watStack.Any() ? string.Join(" ", watStack) : string.Join(" ", flowStack));
            Console.WriteLine(WTF.Any() ? string.Join(" ", WTF) : "None");
        }
    }
}
