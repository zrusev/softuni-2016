using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s1 = Console.ReadLine().Split();
            string[] s2 = Console.ReadLine().Split();
            int length = 0;
            int length1 = 0;

            for (int i = 0; i < Math.Min(s1.Length, s2.Length); i++)
            {
                if (s1[i] == s2[i])
                {
                    length++;
                }
                else
                {
                    break;
                }
            }
            int s1Len = s1.Length - 1;
            int s2Len = s2.Length - 1;
            for (int i = Math.Min(s1.Length, s2.Length); i > 0; i--)
            {
                if (s1[s1Len] == s2[s2Len])
                {
                    length1++;
                    s1Len--;
                    s2Len--;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(Math.Max(length, length1));
        }
    }
}
