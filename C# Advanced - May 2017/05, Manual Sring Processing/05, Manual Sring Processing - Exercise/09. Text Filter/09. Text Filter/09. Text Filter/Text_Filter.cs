using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Text_Filter
{
    public class Text_Filter
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split(new []{ ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();

            for (int i = 0; i < words.Length; i++)
            {
                text = text.Replace(words[i], GetWordCount(words[i]));
            }

            Console.WriteLine(text);

        }

        private static string GetWordCount(string s)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append('*');
            }
            return sb.ToString();
        }
    }
}
