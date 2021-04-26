<Query Kind="Program" />

// C# Masterclass. 02. C# Tips and Tricks
// Records
// Value equality

public record Person(string FirstName, string LastName, string[] PhoneNumbers);

public static void Main()
{
	var phoneNumbers = new string[2];
	Person person1 = new("Petar", "Petrov", phoneNumbers);
	Person person2 = new("Petar", "Petrov", phoneNumbers);
	(person1 == person2).Dump("person1 == person2");
	person1.PhoneNumbers[0] = "555-1234";
	(person1 == person2).Dump("person1 == person2 (phone modified)");

	ReferenceEquals(person1, person2)
		.Dump("ReferenceEquals(person1, person2)");
	ReferenceEquals(person1.PhoneNumbers, person2.PhoneNumbers)
		.Dump("ReferenceEquals(person1.PhoneNumbers, person2.PhoneNumbers)");
}