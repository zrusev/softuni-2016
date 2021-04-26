<Query Kind="Statements" />

// C# Masterclass. 04. Expression Trees
// Func<T>

int Sum(int a, int b) => a + b;
int Mult(int a, int b) => a * b;
Func<int, int, int> Substr = (int a, int b) => a - b;
Func<int, int, int> Dev = (int a, int b) => a / b;

int Calculator(Func<int, int, int> method, int a, int b) => method(a, b);

Console.WriteLine("Func<T>");
Calculator(Sum, 1, 5).Dump("1 + 5");
Calculator(Mult, 3, 5).Dump("3 * 5");
Calculator(Substr, 10, 5).Dump("10 - 5");
Calculator(Dev, 20, 5).Dump("20 / 5");