namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;
    using System;
    using System.Linq;
    public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;
        private bool isRunning;

        private ISetController setCоntroller;
        private IFestivalController festivalCоntroller;
		
        public Engine(IReader reader, IWriter writer, ISetController setCоntroller, IFestivalController festivalCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.isRunning = false;

            this.setCоntroller = setCоntroller;
            this.festivalCоntroller = festivalCоntroller;
        }

		public void Run()
		{

            this.isRunning = true;

            while (this.isRunning)
			{
                string input = this.reader.ReadLine();
                if (input == "END")
                {
                    this.isRunning = false;
                    continue;
                }

                try
				{
					var result = ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split().ToArray();

			var command = tokens[0];
			var parameters = tokens.Skip(1).ToArray();

			if (command == "LetsRock")
			{
				var sets = this.setCоntroller.PerformSets();
                return sets;
			}

            var result = string.Empty;

                switch (command)
                {
                    case "RegisterSet":
                        result = this.festivalCоntroller.RegisterSet(parameters);
                        break;
                    case "SignUpPerformer":
                        result = this.festivalCоntroller.SignUpPerformer(parameters);
                        break;
                    case "RegisterSong":
                        result = this.festivalCоntroller.RegisterSong(parameters);
                        break;
                    case "AddSongToSet":
                        result = this.festivalCоntroller.AddSongToSet(parameters);
                        break;
                    case "AddPerformerToSet":
                        result = this.festivalCоntroller.AddPerformerToSet(parameters);
                        break;
                    case "RepairInstruments":
                        result = this.festivalCоntroller.RepairInstruments(parameters);
                        break;
                    default:
                        break;
                }

			return result;
		}
	}
}