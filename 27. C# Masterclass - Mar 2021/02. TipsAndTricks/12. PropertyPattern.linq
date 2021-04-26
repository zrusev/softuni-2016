<Query Kind="Program" />

// C# Masterclass. 02. C# Tips and Tricks
// Switch Expressions
// Property pattern

class Guest
{
	public string Name { get; set; }

	public string Country { get; set; }
}

static string Greeting(Guest guest) =>
	guest switch
	{
		{ Country: "BG" } => $"Здрасти { guest.Name }",
		{ Country: "RU" } => $"Здравствуй { guest.Name }",
		{ Country: "DE" } => $"Hallo { guest.Name }",
		_ => $"Hello { guest.Name }"
	};

void Main()
{
	Guest guest = new Guest() { Name = "Пешо", Country = "BG" };
	Guest guestRu = new Guest() { Name = "Миша", Country = "RU" };
	Guest guestDe = new Guest() { Name = "Hans", Country = "DE" };
	Guest guestUk = new Guest() { Name = "John", Country = "UK" };

	Greeting(guest).Dump();
	Greeting(guestRu).Dump();
	Greeting(guestDe).Dump();
	Greeting(guestUk).Dump();
}