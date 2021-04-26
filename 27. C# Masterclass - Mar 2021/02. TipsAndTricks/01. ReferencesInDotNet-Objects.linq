<Query Kind="Program" />

using System.Collections.Generic;
using System;

void Main()
{
	var person1 = new Person { Id = 1, Name = "Eric" };
	var person2 = new Person { Id = 1, Name = "Eric" };
	
	var personList = new List<Person> { person1 };
	var personDictionary = new Dictionary<Person, int> { { person1, 1} };
	Console.WriteLine($"person1.Equals(person2) = { person1.Equals(person2) }");
	Console.WriteLine($"personList.Contains(person2) = { personList.Contains(person2) }");
  	Console.WriteLine($"personDictionary.ContainsKey(person2) = { personDictionary.ContainsKey(person2) }");
}

public class Person
{
   public int Id { get; set; }
   public string Name { get; set; }
   
   public override bool Equals(object obj)
   {
	   	var person = obj as Person;
		
		if(person == null) return false;
		
		return person.Id == this.Id && person.Name == this.Name;
   }
   
   public override int GetHashCode() => new { this.Id, this.Name }.GetHashCode();   
}