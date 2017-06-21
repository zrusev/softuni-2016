using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Group_by_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();
            while (true)
            {
                var arguments = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (arguments[0] == "END")
                {
                    break;
                }
                var person = new Person
                {
                    Name = arguments[0] + ' ' + arguments[1],
                    Group = int.Parse(arguments[2])
                };

                persons.Add(person);
            }

            var groups = persons.GroupBy(person => person.Group, person => person.Name);
            foreach (var group in groups.OrderBy(g => g.Key))
            {
                Console.WriteLine($"{group.Key} - {string.Join(", ", group)}");
            }
        }

        private class Person
        {
            public string Name { get; set; }

            public int Group { get; set; }
        }
    }
}

