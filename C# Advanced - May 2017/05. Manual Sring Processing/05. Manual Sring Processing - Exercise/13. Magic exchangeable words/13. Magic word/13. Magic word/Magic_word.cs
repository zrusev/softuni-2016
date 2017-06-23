using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Magic_word
{
    public class Magic_word
    {
        public static void Main()
        {

            var text = "abababa";
            var t = "baba";
            var ta = text.IndexOf(t);

            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(CheckCompatibility(input[0], input[1]).ToString().ToLower());

        }

        public static bool CheckCompatibility(string a, string b)
        {

            char[] arrA = a.ToCharArray();
            char[] arrB = b.ToCharArray();
            var result = false;

            var set1 = new HashSet<char>();
            var set2 = new HashSet<char>();

            for (int i = 0; i < arrA.Length; i++)
            {
                set1.Add(arrA[i]);
            }

            for (int i = 0; i < arrB.Length; i++)
            {
                set2.Add(arrB[i]);
            }
            if (set1.Count == set2.Count)
            {
                result = true;
            }
            return result;
        }    
    }
}
