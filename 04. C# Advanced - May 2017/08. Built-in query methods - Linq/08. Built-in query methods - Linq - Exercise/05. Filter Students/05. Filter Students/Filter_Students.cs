using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Filter_Students
{
    class Filter_Students
    {
        static void Main(string[] args)
        {
            var list = new List<string[]>();
            var input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                list.Add(tokens);

                input = Console.ReadLine();
            }

                list
                .Select(w =>
                    {
                        var words = w[2].Split('@');
                        var firstName = w[0];
                        var lastName = w[1];
                        var email = words[1];
                        return new {firstName, lastName, email};
                    }
                )
                .Where(x => x.email.Equals("gmail.com")).ToList().ForEach(w => Console.WriteLine($"{w.firstName} {w.lastName}")); 
        }
    }
}
