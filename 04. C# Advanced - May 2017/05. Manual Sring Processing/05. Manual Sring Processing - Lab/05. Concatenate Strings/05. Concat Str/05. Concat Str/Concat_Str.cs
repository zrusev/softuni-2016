using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Concat_Str
{
    public class Concat_Str
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();
            
            for (int i = 0; i < n; i++)
            {
                builder = builder.Append(Console.ReadLine() + " ");
            }

            Console.WriteLine(builder);
        }
    }
}
