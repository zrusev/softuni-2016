namespace HashSet
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            HashSet<int> setA = new HashSet<int>();

            setA.Add(5);
            setA.Add(10);
            setA.Add(1);
            setA.Add(2);
            setA.Add(200);

            HashSet<int> setB = new HashSet<int>();

            setB.Add(5);
            setB.Add(10);
            setB.Add(1);
            setB.Add(2);
            setB.Add(100);
            setB.Add(1000);

            HashSet<int> unionSet = setA.UnionWith(setB);
            Console.WriteLine("unionSet: " + string.Join(", ", unionSet));

            HashSet<int> intersectionSet = setA.IntersectsWith(setB);
            Console.WriteLine("intersectionSet: " + string.Join(", ", intersectionSet));

            HashSet<int> exceptionSet = setA.Except(setB);
            Console.WriteLine("exceptionSet: " + string.Join(", ", exceptionSet));

            HashSet<int> symmetricExceptionSet = setA.SymmetricExcept(setB);
            Console.WriteLine("symmetricExceptionSet: " + string.Join(", ", symmetricExceptionSet));
        }
    }
}
