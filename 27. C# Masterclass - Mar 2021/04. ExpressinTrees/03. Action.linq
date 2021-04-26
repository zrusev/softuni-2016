<Query Kind="Statements" />

// C# Masterclass. 04. Expression Trees
// Action<T>

void Sum(int a, int b) => Console.WriteLine($"{a} + {b} = {a + b}");
void Mult(int a, int b) => Console.WriteLine($"{a} * {b} = {a * b}");
Action<int, int> Substr = (int a, int b) => Console.WriteLine($"{a} - {b} = {a - b}");
Action<int, int> Dev = (int a, int b) => Console.WriteLine($"{a} / {b} = {a / b}");

void Calculator(Action<int, int> method, int a, int b) => method(a, b);

Console.WriteLine("Action<T>");
Calculator(Sum, 1, 5);
Calculator(Mult, 3, 5);
Calculator(Substr, 10, 5);
Calculator(Dev, 20, 5);