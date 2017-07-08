using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.NMS
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine;
            var stack = new Queue<char>();
            var printBuilder = new StringBuilder();

            while ((inputLine = Console.ReadLine()) != "---NMS SEND---")
            {
                var charArr = inputLine.ToCharArray();
                for (int i = 0; i < charArr.Length; i++)
                {
                    stack.Enqueue(charArr[i]);
                }
            }

            var delimiter = Console.ReadLine();

            if (inputLine.Equals(delimiter))
            {
                var charArr = inputLine.ToCharArray();
                for (int i = 0; i < charArr.Length; i++)
                {
                    stack.Enqueue(charArr[i]);
                }
            }

            var maxCount = stack.Count;
            for (int i = 0; i < maxCount - 1; i++)
            {
                var currentElement = stack.Dequeue();
                if (Char.ToLower(currentElement) <= Char.ToLower(stack.Peek()))
                {
                    printBuilder.Append(currentElement);
                }
                else
                {
                    printBuilder.Append(currentElement);
                    printBuilder.Append(delimiter);
                }
            }
            printBuilder.Append(stack.Dequeue());

            Console.WriteLine(printBuilder);
        }
    }
}
