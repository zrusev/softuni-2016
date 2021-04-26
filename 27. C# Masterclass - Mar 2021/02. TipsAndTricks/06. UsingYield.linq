<Query Kind="Statements" />

// C# Masterclass. 02. C# Tips and Tricks
// Using yield

IEnumerable<int> EvenNums(int from, int to)
{
	for (int i = from; i <= to; i++)
	{
		if (i % 2 == 0)
		{
			yield return i;
		}
	}
}

foreach (var n in EvenNums(51, 60))
{
	Console.WriteLine(n);
}