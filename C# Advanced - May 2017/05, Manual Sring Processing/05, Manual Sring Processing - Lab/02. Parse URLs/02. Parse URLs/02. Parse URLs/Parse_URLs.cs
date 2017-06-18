using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Parse_URLs
{
    public class Parse_URLs
    {
        public static void Main()
        {
            var url = Console.ReadLine();
            string separator = "://";
            var urlTokens = url.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);

            if (urlTokens.Length != 2 || urlTokens[1].IndexOf('/') == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else
            {
                var protocol = urlTokens[0];
                var indexResource = urlTokens[1].IndexOf('/');
                var server = urlTokens[1].Substring(0, indexResource);
                var resources = urlTokens[1].Substring(indexResource + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }



        }
    }
}
