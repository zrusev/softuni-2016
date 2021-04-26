<Query Kind="Program" />

// C# Masterclass. 02. C# Tips and Tricks
// Virtual Call In Constructor

abstract class Base
{
	protected Base()
	{
		VFunc();
	}

	protected abstract void VFunc();
}

class Derived : Base
{
	private readonly string msg = "Set by initializer";

	public Derived(string msg)
	{
		this.msg = msg;
	}

	protected override void VFunc()
	{
		Console.WriteLine(msg);
	}
	
	public static void Main()
	{
		var d = new Derived("Set by constructor");
	}
}