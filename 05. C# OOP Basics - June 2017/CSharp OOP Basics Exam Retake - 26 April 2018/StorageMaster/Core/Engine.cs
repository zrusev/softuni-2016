namespace StorageMaster.Core
{
    using Controllers;
    using IO.Contracts;
    using System;
    using System.Linq;
    public class Engine
    {
        private bool isRunning;

        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly StorageMaster storageMaster;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string command = this.reader.ReadLine();
                try
                {
                    this.ReadCommand(command);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine("Error: " + e.Message);
                }

                if (command == "END")
                {
                    this.writer.WriteLine(this.storageMaster.GetSummary());
                    this.isRunning = false;
                }
            }
        }
        private void ReadCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                this.isRunning = false;
                return;
            }

            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;
            switch (commandName)
            {
                case "AddProduct":
                    var productType = args[0];
                    var productPrice = double.Parse(args[1]);

                    output = this.storageMaster.AddProduct(productType, productPrice);
                    break;
                case "RegisterStorage":
                    var storageType = args[0];
                    var storageName = args[1];

                    output = this.storageMaster.RegisterStorage(storageType, storageName);
                    break;
                case "SelectVehicle":
                    var selectedVehicle = args[0];
                    var garageSlot = int.Parse(args[1]);

                    output = this.storageMaster.SelectVehicle(selectedVehicle, garageSlot);
                    break;
                case "LoadVehicle":

                    output = this.storageMaster.LoadVehicle(args);
                    break;
                case "SendVehicleTo":
                    var sourceName = args[0];
                    var sourceGarageSlot = int.Parse(args[1]);
                    var destinationName = args[2];

                    output = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                    break;
                case "UnloadVehicle":
                    var storageNameFrom = args[0];
                    var garageSlotFrom = int.Parse(args[1]);

                    output = this.storageMaster.UnloadVehicle(storageNameFrom, garageSlotFrom);
                    break;
                case "GetStorageStatus":
                    var storageStatus = args[0];

                    output = this.storageMaster.GetStorageStatus(storageStatus);
                    break;
            }

            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}
