<Query Kind="Statements" />

try 
{
	 Console.WriteLine("{0} divided by 2 is {1}", 7, DivideByTwo(7));
}
catch (ArgumentException e)
{
	throw;
}


 int DivideByTwo(int num)
{
    if ((num & 1) == 1) 
	{
		throw new ArgumentException(String.Format("{0} is not an even number", num), "num");
	}

    return num / 2;
}