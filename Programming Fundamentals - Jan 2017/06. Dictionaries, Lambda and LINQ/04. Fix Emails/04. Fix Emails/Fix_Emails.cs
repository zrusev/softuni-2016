namespace _04.Fix_Emails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Fix_Emails
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();
            var name = string.Empty;
            var email = string.Empty;

            while (true)
            {
                name = Console.ReadLine();
                if (name.Equals("stop", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                email = Console.ReadLine();
                var tst = email.Substring(email.Length - 2).Equals("us", StringComparison.OrdinalIgnoreCase);
                var tst2 = email.Substring(email.Length - 2).Equals("uk", StringComparison.OrdinalIgnoreCase);
                if (!tst && !tst2)
                {
                    dict.Add(name, email);
                }
            }

            foreach (var el in dict)
            {
                Console.WriteLine($"{el.Key} -> {el.Value}");
            }
            
        }
    }
}
