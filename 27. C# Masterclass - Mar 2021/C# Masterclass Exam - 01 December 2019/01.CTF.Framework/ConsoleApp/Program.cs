namespace ConsoleApp
{
    using System;
    using CTF.Framework.TestRunner;

    public class Program
    {
        public static void Main()
        {
            string assemblyPath = string.Empty;
            
            Runner runner = new Runner();
            
            string result = runner.Run(assemblyPath);
            
            Console.WriteLine(result);
        }
    }
}