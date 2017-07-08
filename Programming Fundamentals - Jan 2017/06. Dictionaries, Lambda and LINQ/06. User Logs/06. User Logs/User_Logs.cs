namespace _06.User_Logs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
   
    class User_Logs
    {
        static void Main()
        {
            var dict = new SortedDictionary<string, List<string>>();
            var input = string.Empty;
            var user = string.Empty;
            var ip = string.Empty;

            while (true)
            {
                input = Console.ReadLine();

                if (input.Equals("end", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                user = input.Substring(input.IndexOf("user=") + 5);

                if (!dict.ContainsKey(user))
                {
                    var listOfIps = new List<string>();
                    ip = input.Substring(3, input.IndexOf("message=") - 4);
                    listOfIps.Add(ip);
                    dict.Add(user, listOfIps);
                }
                else
                {
                    ip = input.Substring(3, input.IndexOf("message=") - 4);
                    dict[user].Add(ip);
                }
            }


            foreach (var item in dict)
            {

                    Console.WriteLine(item.Key + ": ");
                    //Console.WriteLine(string.Join(" " + "=> " + item.Value.Distinct().Count() + "\n", item.Value.Distinct()));
                    var items = item.Value
                    .GroupBy(g => g)
                    .Select(t => new { count = t.Count(), key = t.Key });
                var last = items.Last();
                foreach (var group in items)
                {
                    if (!group.Equals(last))
                    {
                        Console.Write(group.key + " => " + group.count + ", ");
                    }
                    else
                    {
                        Console.WriteLine(group.key + " => " + group.count + ". ");
                    }

                }
            }

        }
    }
}
