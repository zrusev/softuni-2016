using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Count_Sub
{
    public class Count_Sub
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var part = Console.ReadLine().ToLower();
            var count = 0;
            for (int i = 0; i < text.Length - part.Length; i++)
            {

                if (text.Substring(i, part.Length).Equals(part))
                {
                    count++;
                }                
            }

            if (text.Substring(text.Length - part.Length).Equals(part))
            {
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
