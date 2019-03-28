namespace BillsPaymentSystem.App
{
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                DbInitializer.Seed(context);
            }

            //ICommandInterpreter commandInterpreter = new CommandInterpreter();
            //IEngine engine = new Engine(commandInterpreter);
            //engine.Run();
        }
    }
}