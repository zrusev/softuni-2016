<Query Kind="Statements" />

// C# Masterclass. 02. C# Tips and Tricks
// Switch Expressions
// Realational pattern 
// Including: Parenthesized pattern, Conjunctive 'and' pattern, Disjunctive 'or' pattern

static bool IsLatinLetter(char c) =>
	c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');

IsLatinLetter('v').Dump("'v' is latin letter");
IsLatinLetter('о').Dump("'о' is latin letter");
IsLatinLetter('o').Dump("'o' is latin letter");