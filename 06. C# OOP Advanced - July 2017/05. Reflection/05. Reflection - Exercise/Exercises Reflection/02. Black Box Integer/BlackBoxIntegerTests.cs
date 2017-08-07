using System.Linq;
using System.Reflection;

namespace _02BlackBoxInteger
{
    using System;
    public class BlackBoxIntegerTests
    {
        private const BindingFlags NonPublicFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        public static void Main()
        {
            Type blackBoxType = typeof(BlackBoxInt);
            BlackBoxInt myBlackBox = (BlackBoxInt) Activator.CreateInstance(blackBoxType, true);
            //ConstructorInfo blackBoxCtor = blackBoxType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,Type.DefaultBinder, new Type[] { }, null);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('_');
                string methodName = tokens[0];
                int value = int.Parse(tokens[1]);

                blackBoxType.GetMethod(methodName, NonPublicFlags)
                    .Invoke(myBlackBox, new object[] {value});
                object innerStateValue = blackBoxType.GetFields(NonPublicFlags).First().GetValue(myBlackBox);

                Console.WriteLine(innerStateValue);
            }
        }
    }
}
