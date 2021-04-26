<Query Kind="Program" />

// C# Masterclass. 02. C# Tips and Tricks
// Switch Expressions
// Positional pattern

public class Point
{
	public int X { get; }
	public int Y { get; }

	public Point(int x, int y) => (X, Y) = (x, y);

	public void Deconstruct(out int x, out int y) =>
		(x, y) = (X, Y);
}

public enum Quadrant
{
	Unknown,
	Origin,
	One,
	Two,
	Three,
	Four,
	OnBorder
}

static Quadrant GetQuadrant(Point point) => point switch
{
	(0, 0) => Quadrant.Origin,
	var (x, y) when x > 0 && y > 0 => Quadrant.One,
	var (x, y) when x < 0 && y > 0 => Quadrant.Two,
	var (x, y) when x < 0 && y < 0 => Quadrant.Three,
	var (x, y) when x > 0 && y < 0 => Quadrant.Four,
	var (_, _) => Quadrant.OnBorder,
	_ => Quadrant.Unknown
};

void Main()
{
	Point pt1 = new Point(3, -5);
	Point pt2 = new Point(7, 15);
	Point pt3 = new Point(-6, -5);
	Point pt4 = new Point(0, -5);

	GetQuadrant(pt1).Dump();
	GetQuadrant(pt2).Dump();
	GetQuadrant(pt3).Dump();
	GetQuadrant(pt4).Dump();
}