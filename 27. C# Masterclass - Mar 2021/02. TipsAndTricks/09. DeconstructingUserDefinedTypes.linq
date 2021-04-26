<Query Kind="Statements" />

// C# Masterclass. 02. C# Tips and Tricks
// Deconstructing user-defined types

var p = new Person()
{
	FirstName = "Petar",
	MiddleName = "Ivanov",
	LastName = "Petrov",
	Age = 25
};

//(string fName, string mName, string lName) = p;
var (fName, mName, lName) = p;
$"{fName} {mName} {lName}".Dump("Person's fullname");

//(string name, _, _, int age) = p;
var (name, _, _, age) = p;
$"{name} is {age} years old".Dump("Persons age");

//p.FirstName = "Gosho";

/// <summary>
/// Class with Deconstructor
/// </summary>
class Person
{
	public string FirstName { get; init; }
	
	public string MiddleName { get; init; }
	
	public string LastName { get; init; }
	
	public int Age { get; set; }
	
	public void Deconstruct(out string firstName, out string middleName, out string lastName)
	{
		firstName = FirstName;
		middleName = MiddleName;
		lastName = LastName;
	}

	public void Deconstruct(out string firstName, out string middleName, out string lastName, out int age)
	{
		firstName = FirstName;
		middleName = MiddleName;
		lastName = LastName;
		age = Age;
	}
}