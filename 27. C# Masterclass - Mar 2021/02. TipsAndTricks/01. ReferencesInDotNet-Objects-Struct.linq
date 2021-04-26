<Query Kind="Program" />

using System.Collections.Generic;
using System;

void Main()
{
	var person1 = new Person { Id = 1, Name = "Eric" };
	var person2 = new Person { Id = 1, Name = "Eric" };
	
	var personList = new List<Person> { person1 };
	var personDictionary = new Dictionary<Person, int> { { person1, 1} };
	Console.WriteLine($"person1.Equals(person2) = { person1 == person2 }");
	Console.WriteLine($"personList.Contains(person2) = { personList.Contains(person2) }");
  	Console.WriteLine($"personDictionary.ContainsKey(person2) = { personDictionary.ContainsKey(person2) }");
}

public struct Person : IEquatable<Person>
{
   	public int Id { get; set; }
   	public string Name { get; set; }
   
   	//public bool Equals(Person person) => person.Id == this.Id && person.Name == this.Name;
	public bool Equals(Person person) => (this.Id ,this.Name).Equals((person.Id, person.Name));

	public override bool Equals(object obj) => (obj is Person) && this.Equals((Person) obj);

	//public override int GetHashCode() => new { this.Id, this.Name }.GetHashCode();
	public override int GetHashCode() => (this.Id, this.Name).GetHashCode();

    public static bool operator ==(Person p1, Person p2) => (!object.ReferenceEquals(p1, null)) && p1.Equals(p2);
	
	public static bool operator !=(Person p1, Person p2) => !(p1 == p2);
}