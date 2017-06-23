using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sum_big_num
{
    public class Sum_big_num
    {
        public static void Main()
        {
            var firstNum = Console.ReadLine().TrimStart('0');
            var secondNum = Console.ReadLine().TrimStart('0');

            var firstNums = new Stack<char>(firstNum);
            var secondNums = new Stack<char>(secondNum);

            var finalNum = new Stack<int>();

            var nextNum = 0;

            while (firstNums.Count > 0 && secondNums.Count > 0)
            {
                var first = int.Parse(firstNums.Pop().ToString());
                var second = int.Parse(secondNums.Pop().ToString());
                var sum = first + second + nextNum;

                if (sum < 10)
                {
                    finalNum.Push(sum);
                    nextNum = 0;
                }

                else
                {
                    finalNum.Push(sum % 10);
                    nextNum = 1;
                }
            }

            var longerNum = GetQueueLeft(firstNums, secondNums);

            while (longerNum.Count > 0)
            {
                var num = int.Parse(longerNum.Pop().ToString());
                var sum = nextNum + num;

                if (sum < 10)
                {
                    finalNum.Push(sum);
                    nextNum = 0;
                }

                else
                {
                    finalNum.Push(sum % 10);
                    nextNum = 1;
                }
            }

            if (nextNum == 1)
            {
                finalNum.Push(1);
            }

            var sb = new StringBuilder();

            while (finalNum.Count != 0)
            {
                sb.Append(finalNum.Pop());
            }

            Console.WriteLine(sb);
        }

        private static Stack<char> GetQueueLeft(Stack<char> firstNums, Stack<char> secondNums)
        {
            if (firstNums.Count > 0)
            {
                return firstNums;
            }

            else
            {
                return secondNums;
            }
        }
    }
}
