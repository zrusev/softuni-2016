namespace CTF.Framework.TestRunner
{
    using Attributes;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Runner
    {
        private readonly StringBuilder stringBuilder;

        private const string TEST_ASSEMBLY = "Calculator.Tests";

        public Runner()
            => this.stringBuilder = new StringBuilder();
        
        public string Run(string assemblyPath)
        {
            var callerAssemblyName = Assembly.GetEntryAssembly().GetName().Name;

            //ToDo: both assemblies should have the same .netcore version 
            string targetDirectory = Directory.GetCurrentDirectory().Replace(callerAssemblyName, TEST_ASSEMBLY);

            var path = !String.IsNullOrWhiteSpace(assemblyPath)
                ? assemblyPath
                : Path.Combine(targetDirectory, $"{TEST_ASSEMBLY}.dll");

            Assembly assembly = Assembly.LoadFrom(path);

            var testClasses = assembly
                .GetTypes()
                .Where(t => t.IsDefined(typeof(CTFTestClassAttribute), true));

            foreach (var testClass in testClasses)
            {
                var testInstance = Activator.CreateInstance(testClass);

                var tests = testClass
                    .GetMethods()
                    .Where(m => m.IsDefined(typeof(CTFTestMethodAttribute), true));

                foreach (var test in tests)
                {
                    try
                    {
                        test.Invoke(testInstance, new object[0]);

                        this.stringBuilder.AppendLine($"Class: {testClass.Name} Method: {test.Name} - passed!");
                    }
                    catch
                    {
                        this.stringBuilder.AppendLine($"Class: {testClass.Name} Method: {test.Name} - failed!");
                        this.stringBuilder.AppendLine($"Unexpected error occurred in {test.Name}!");
                    }
                }
            }

            return this.stringBuilder.ToString();
        }
    }
}