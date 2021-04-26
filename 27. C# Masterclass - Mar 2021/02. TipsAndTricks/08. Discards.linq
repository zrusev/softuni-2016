<Query Kind="Statements" />

// C# Masterclass. 02. C# Tips and Tricks
// Discards

IsValidInt("23").Dump("23 is valid int");
IsValidInt("Pesho").Dump("Pesho is valid int");
IsValidInt(null).Dump("Pesho is valid int");

// Discard out parameter
static bool IsValidInt(string number) => int.TryParse(number, out _);

SayHi("Pesho");
//SayHi(null);

// Standalone discard
static void SayHi(string name)
{
	_ = name ?? throw new ArgumentException(message: "Argument can not be null", paramName: nameof(name));

	Console.WriteLine($"Hi, {name}");
}

// Discard input parameter of a lambda Expression
string Password = "verysecretpassword";
Password.Select(_ => '*').Dump();