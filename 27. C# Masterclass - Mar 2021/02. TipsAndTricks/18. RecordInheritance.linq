<Query Kind="Program" />

// C# Masterclass. 02. C# Tips and Tricks
// Records
// Record Inheritance

public abstract record Person(string FirstName, string LastName);
public record Student(string FirstName, string LastName, string Course)
	: Person(FirstName, LastName);
	
public static void Main()
{
	Person student = new Student("Petar", "Petrov", "C# MasterClass");
	Student student2 = new Student("Petar", "Petrov", "C# MasterClass");
	
	(student2 == student).Dump("student2 == student"); 
}