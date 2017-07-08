using System.Linq;
using _03.Oldest_Family_Member;

namespace _04.Opinion_Poll
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main()
        {
            var list = new List<Person>();
            var familyMembers = int.Parse(Console.ReadLine());
            for (int i = 0; i < familyMembers; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var age = int.Parse(input[1]);

                var familyMember = new Person();
                familyMember.Name = name;
                familyMember.Age = age;

                if (age > 30)
                {
                    list.Add(familyMember);
                }
            }

            list.OrderBy(x => x.Name).ToList().ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
        }
    }
}
