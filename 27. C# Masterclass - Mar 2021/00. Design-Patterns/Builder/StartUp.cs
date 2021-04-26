namespace Builder
{
    using System;
    using Factories;
    
    public class StartUp
    {
        public static void Main()
        {
            SandwichBuilder builder = new TurkeyClub();
            AssemblyLine line = new AssemblyLine();
 
            line.Assemble(builder);
            builder.Sandwich.Show();
        }
    }
}