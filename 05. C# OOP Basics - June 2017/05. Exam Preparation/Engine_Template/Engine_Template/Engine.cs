using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    //CREATE CLASS OBJECT

    public Engine()
    {
        this.isRunning = true;
        //INITIALIZE THE CLASS OBJECT
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string inputCommand = this.ReadInput();
            List<string> commandParameters = this.ParseInput(inputCommand);
            this.DistributeCommand(commandParameters);
        }
    }


    private List<string> ParseInput(string inputCommand)
    {
        return inputCommand.Split(new []{' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ReadInput()
    {
        return Console.ReadLine();
    }


    private void DistributeCommand(List<string> commandParameters)
    {
        string command = commandParameters[0];
        commandParameters.Remove(command);

        switch (command)
        {
            case "1":
                //CALL CLASS OBJECT'S METHOD AND PASS PARAMETERS
                break;
            case "2":
                //CALL CLASS OBJECT'S METHOD AND PASS PARAMETERS
                break;
            case "3":
                //CALL CLASS OBJECT'S METHOD AND PASS PARAMETERS
                break;
            case "4":
                //CALL CLASS OBJECT'S METHOD AND PASS PARAMETERS
                break;
            case "Quit":
                //CALL CLASS OBJECT'S METHOD AND PASS PARAMETERS IF NEEDED
                this.isRunning = false;
                break;
        }
    }
    
}