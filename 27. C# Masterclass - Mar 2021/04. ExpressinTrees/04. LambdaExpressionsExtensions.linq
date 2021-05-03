<Query Kind="Program" />

using static Functional.Techniques;

void Main()
{
	//Composition

	Func<int, int> firstFunc = (int i) => i * 2;
	Func<int, int> secondFunc = (int i) => i / 2;
	
	var composedFunction = compose(firstFunc, secondFunc);
	
	var composedResult = composedFunction(2);
	
	Console.WriteLine($"Function composition example: {composedResult}");
	
	Console.WriteLine("-------------");

	//Currying
	
	Func<int, int, int> thirdFunc = (int a, int b) => a * b;

	var curryFunction = curry(thirdFunc);
	
	var curryResult1 = curryFunction(2);
	var curryResult2 = curryResult1(2);
	
	Console.WriteLine($"Currying example: {curryResult2}");
	
	Console.WriteLine("-------------");

	//Partial Application
	
	Func<int, int, int, int> forthFunc = (int a, int b, int c) => a * b * c;

	var partialFunction = partial(forthFunc, 2, 3);
	
	var partialResult = partialFunction(4);
	
	Console.WriteLine($"Partial Application example: {partialResult}");
}

namespace Functional
{
	public static partial class Techniques
	{
		public static Func<A, C> compose<A, B, C>(Func<A, B> a, Func<B, C> b) 
			=> x => b(a(x));
			
		public static Func<A, Func<B, R>> curry<A, B, R>(Func<A, B, R> func)
			=> (A a) => (B b) => func(a, b);
			
		public static Func<C, R> partial<A, B, C, R>(Func<A, B, C, R> func, A a, B b)
			=> (C c) => func(a, b, c);
	}
}