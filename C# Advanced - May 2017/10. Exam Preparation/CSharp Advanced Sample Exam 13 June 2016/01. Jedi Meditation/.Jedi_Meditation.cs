using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Jedi_Meditation
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            var mList = new HashSet<string>();
            var kList = new HashSet<string>();
            var pList = new HashSet<string>();
            var sList = new HashSet<string>();
            //var tList = new HashSet<string>();
            var yList = new HashSet<string>();
            var sb = new StringBuilder();


            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ');

                for (int j = 0; j < tokens.Length; j++)
                {
                    switch (tokens[j][0])
                    {
                        case 'm':
                            mList.Add(tokens[j]);
                            break;
                        case 'k':
                            kList.Add(tokens[j]);
                            break;
                        case 'p':
                            pList.Add(tokens[j]);
                            break;
                        case 's':
                            sList.Add(tokens[j]);
                            break;
                        case 't':
                            sList.Add(tokens[j]);
                            break;
                        case 'y':
                            yList.Add(tokens[j]);
                            break;
                    }
                }
            }

            if (yList.Count != 0)
            {
                sb.Append($"{string.Join(" ", mList)} ");
                sb.Append($"{string.Join(" ", kList)} ");
                sb.Append($"{string.Join(" ", sList)} ");
                sb.Append($"{string.Join(" ", pList)} ");
            }
            else
            {
                sb.Append($"{string.Join(" ", sList)} ");
                sb.Append($"{string.Join(" ", mList)} ");
                sb.Append($"{string.Join(" ", kList)} ");
                sb.Append($"{string.Join(" ", pList)} ");
            }

            Console.WriteLine(sb);
        }
    }
}
