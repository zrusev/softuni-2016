<Query Kind="Program" />

// C# Masterclass. 02. C# Tips and Tricks
// Exceptions & Static Constructors

/// <summary>
/// Class with static constructor
/// The constructor executes only once
/// The type remains uninitialized 
/// for the lifetime of the application
/// </summary>
public sealed class Bang
{
	static Bang()
	{
		Console.WriteLine("In static constructor");
		throw new Exception("Bang!");
	}

	public static void Foo() { }
}

class Test
{
	static void Main()
	{
		for (int i = 0; i < 5; i++)
		{
			try
			{
				Bang.Foo();
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.GetType().Name}. Message: {e.Message}");
			}
		}
	}
}