<Query Kind="Statements" />

// C# Masterclass. 04. Expression Trees
// Lambda Expressions

// You enclose input parameters of a lambda expression in parentheses. 
// Specify zero input parameters with empty parentheses
Action helloWorld = () => Console.WriteLine("Hello, world!!!");

// If a lambda expression has only one input parameter, parentheses are optional
Func<double, double> cube = x => x * x * x;

// Two or more input parameters are separated by commas
Func<int, int, bool> testForEquality = (x, y) => x == y;

// Sometimes the compiler can't infer the types of input parameters. 
// You can specify the types explicitly
Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;

// Beginning with C# 9.0, you can use discards to specify two or more 
// input parameters of a lambda expression that aren't used in the expression
Func<int, int, int> constant = (_, _) => 42;

// ------------------------------------------------------------------------

helloWorld();

cube(9).Dump("9 in cube");

testForEquality(8, 3).Dump("8 is equal to 3");

isTooLong(5, "Summertime").Dump("Summertime is more than 5 characters");

constant(8, 7).Dump("The answer to the Ultimate Question of Live, Universe and Everithing");

// -------------------------------------------------------------------------

Func<(int n1, int n2, int n3), (int, int, int)> doubleThem = ns => (2 * ns.n1, 2 * ns.n2, 2 * ns.n3);
var numbers = (2, 3, 4);
var doubledNumbers = doubleThem(numbers);

Console.WriteLine($"The set {numbers} doubled: {doubledNumbers}");

// -------------------------------------------------------------------------


