namespace _03.Unicode_Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Unicode_Characters
    {
        static void Main()
        {
            var unicodeString = Console.ReadLine();
            var result = unicodeString.Select(t => string.Format("u{0:x4} ", Convert.ToUInt16(t))).ToList();
            var output = new StringBuilder();
            foreach (var item in result)
            {
                output.Append("\\" + item.Trim()).ToString();
            }
            Console.WriteLine(output);
        }
    }
}
