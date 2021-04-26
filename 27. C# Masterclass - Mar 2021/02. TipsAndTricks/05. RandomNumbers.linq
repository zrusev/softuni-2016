<Query Kind="Statements" />

// C# Masterclass. 02. C# Tips and Tricks
// Random Numbers in .NET

var firstRandomNumbersGenerator = new Random();
var secondRandomNumbersGenerator = new Random();

firstRandomNumbersGenerator.Next(100).Dump();
secondRandomNumbersGenerator.Next(100).Dump();