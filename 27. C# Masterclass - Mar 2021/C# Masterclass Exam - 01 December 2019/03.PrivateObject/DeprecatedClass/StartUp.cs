namespace DeprecatedClass
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var summator = new Summator();

            var privateObject = new PrivateObject(summator);
            
            var result = privateObject.Invoke("GetSum", 12, 13);

            Console.WriteLine(result);

            result = privateObject.Invoke("Combine", "I", " am");

            Console.WriteLine(result);
        }
    }
}