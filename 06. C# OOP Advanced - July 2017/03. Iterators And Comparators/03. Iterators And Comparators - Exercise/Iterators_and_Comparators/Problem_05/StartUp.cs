using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Person> people = new List<Person>();

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] tokens = input.Split();

            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string town = tokens[2];

            people.Add(new Person(name, age, town));

            input = Console.ReadLine();
        }

        int numberOfEqualPeople = 0;
        int numberOfNotEqualPeople = 0;

        int personIndex = int.Parse(Console.ReadLine()) - 1;

        Person personToCompareWith = people[personIndex];

        foreach (Person person in people)
        {
            if (person.CompareTo(personToCompareWith) == 0)
            {
                numberOfEqualPeople++;
            }
            else
            {
                numberOfNotEqualPeople++;
            }
        }

        string result = "No matches";

        if (numberOfEqualPeople > 1)
        {
            result = $"{numberOfEqualPeople} {numberOfNotEqualPeople} {people.Count}";
        }
        Console.WriteLine(result);
    }
}