using System;
public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public override int GetHashCode()
    {
        return (this.Name + this.Age).GetHashCode();
    }

    public override bool Equals(object obj)
    {
        Person otherPerson = (Person)obj;
        int result = this.Name.CompareTo(otherPerson.Name);

        if (result == 0)
        {
            result = this.Age.CompareTo(otherPerson.Age);
        }

        var areEqual = result == 0;

        if (areEqual)
        {
            return true;
        }

        return false;
    }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);

        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }
}