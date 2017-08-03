namespace _11.Inferno_Infinity.Core
{
    using System;
    public class Engine
    {
        private CommandInterpreter interpreter;

        public Engine()
        {
            this.interpreter = new CommandInterpreter();
        }

        public void Run()
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputData = input.Split(';');

                switch (inputData[0])
                {
                    case "Add":
                        this.interpreter.Add(inputData[1], int.Parse(inputData[2]), inputData[3]);
                        break;
                    case "Create":
                        this.interpreter.Create(inputData[1], inputData[2]);
                        break;
                    case "Remove":
                        this.interpreter.Remove(inputData[1], int.Parse(inputData[2]));
                        break;
                    case "Print":
                        this.interpreter.Print(inputData[1]);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}