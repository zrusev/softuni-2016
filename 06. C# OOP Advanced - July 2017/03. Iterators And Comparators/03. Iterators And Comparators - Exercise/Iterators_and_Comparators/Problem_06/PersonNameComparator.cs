using System.Collections.Generic;
public class PersonNameComparator : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        int result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

        if (result == 0)
        {
            result = char.ToLowerInvariant(firstPerson.Name[0]).CompareTo(char.ToLowerInvariant(secondPerson.Name[0]));
        }

        return result;
    }
}