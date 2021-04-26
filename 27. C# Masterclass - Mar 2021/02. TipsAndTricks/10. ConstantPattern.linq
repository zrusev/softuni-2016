<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

// C# Masterclass. 02. C# Tips and Tricks
// Switch Expressions
// Constant pattern

void Main()
{
	var color = FromRainbow (Rainbow.Orange);
	new Panel { BackColor = color }.Dump();
}

public static Color FromRainbow (Rainbow colorBand) =>
	colorBand switch
	{
		Rainbow.Red => Color.Red,
		Rainbow.Orange => Color.Orange,
		Rainbow.Yellow => Color.Yellow,
		Rainbow.Green => Color.Green,
		Rainbow.Blue => Color.Blue,
		Rainbow.Indigo => Color.Indigo,
		Rainbow.Violet => Color.Violet,
		_ => throw new ArgumentException (message: "invalid enum value", paramName: nameof (colorBand)),
	};
	
public enum Rainbow
{
	Red,
	Orange,
	Yellow,
	Green,
	Blue,
	Indigo,
	Violet
}