using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var setWithNameComparator = new SortedSet<Person>(new PersonNameComparator());
        var setWithAgeComparator = new SortedSet<Person>(new PersonAgeComparator());

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            var person = new Person(name, age);

            setWithNameComparator.Add(person);
            setWithAgeComparator.Add(person);
        }

        foreach (Person person in setWithNameComparator)
        {
            Console.WriteLine(person);
        }

        foreach (Person person in setWithAgeComparator)
        {
            Console.WriteLine(person);
        }
    }
}