<Query Kind="Program" />

using System;
using System.Linq.Expressions;

public static class New<T>
	where T:  new()
{
	public static Func<T> Instance =
		Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
}

public void Main()
{
	New<Cat>.Instance(); //Warm up

	var slowerCat = Activator.CreateInstance(typeof(Cat));
	var fasterCat = New<Cat>.Instance();
	
	Console.WriteLine(slowerCat.ToString());
	Console.WriteLine(fasterCat.ToString());
}

public class Cat
{
	public override string ToString() => "I am Cat";
}
