namespace FestivalManager.Entities
{
    using Contracts;
    using System.Collections.Generic;

    public class Performer : IPerformer
	{
		private readonly List<IInstrument> instruments;

        public Performer()
        {
            this.instruments = new List<IInstrument>();
        }

		public Performer(string name, int age)
            :this()
		{
			this.Name = name;
			this.Age = age;
		}

		public string Name { get; }

		public int Age { get; }

		public IReadOnlyCollection<IInstrument> Instruments => this.instruments;

		public void AddInstrument(IInstrument instrument)
		{
			this.instruments.Add(instrument);
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
