<Query Kind="Program" />

// C# Masterclass. 02. C# Tips and Tricks
// Switch Expressions
// Type pattern

void Main()
{
	var sequence = new string[] { "first item", "second item", "third item", "fourth item" };
	
	GetThirdItem(sequence).Dump("Switch Expression - Type pattern");
}

public static T GetThirdItem<T>(IEnumerable<T> sequence) =>
	sequence switch
	{
		System.Array { Length: 0 } => default(T),
		System.Array { Length: 1 } array => (T)array.GetValue(0),
		System.Array { Length: 2 } array => (T)array.GetValue(1),
		System.Array array => (T)array.GetValue(2),
		IEnumerable<T> list
			when !list.Any() => default(T),
		IEnumerable<T> list
			when list.Count() < 3 => list.Last(),
		IList<T> list => list[2],
		null => throw new ArgumentNullException(nameof(sequence)),
		_ => sequence.Skip(2).FirstOrDefault()
	};