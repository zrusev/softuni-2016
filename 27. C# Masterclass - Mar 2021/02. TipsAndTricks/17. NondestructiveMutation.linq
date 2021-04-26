<Query Kind="Program" />

// C# Masterclass. 02. C# Tips and Tricks
// Records
// Nondestructive mutation

public record Person(string FirstName, string LastName)
{
	public string[] PhoneNumbers { get; init; }
}

public static void Main()
{
	Person person1 = new("Petar", "Petrov") { PhoneNumbers = new string[1] };
	Console.WriteLine(person1);

	Person person2 = person1 with { FirstName = "George" };
	Console.WriteLine(person2);
	(person1 == person2).Dump("person1 == person2 (FirstName mutated)"); 

	person2 = person1 with { PhoneNumbers = new string[1] };
	Console.WriteLine(person2);
	(person1 == person2).Dump("person1 == person2 (PhoneNumbers mutated)");

	person2 = person1 with { };
	(person1 == person2).Dump("person1 == person2 (without mutation)"); 
}