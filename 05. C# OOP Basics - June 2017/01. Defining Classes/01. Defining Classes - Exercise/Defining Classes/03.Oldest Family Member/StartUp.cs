using System.Reflection;

namespace _03.Oldest_Family_Member
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            var family = new Family();
            var familyMembers = int.Parse(Console.ReadLine());
            for (int i = 0; i < familyMembers; i++)
            {
                var input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var age = int.Parse(input[1]);

                var familyMember = new Person();
                familyMember.Name = name;
                familyMember.Age = age;

                family.AddMember(familyMember);                
            }
            var oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
