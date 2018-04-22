namespace FestivalManager.Entities.Sets
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Set : ISet
	{
		private List<IPerformer> performers;
        private List<ISong> songs;

        public Set()
        {
            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

		public Set(string name, TimeSpan maxDuration)
            :this()
		{
			this.Name = name;
			this.MaxDuration = maxDuration;
        }

		public string Name { get; }

		public TimeSpan MaxDuration { get; }

		public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

		public IReadOnlyCollection<IPerformer> Performers
		{
			get { return performers.AsReadOnly(); }
		}

		public IReadOnlyCollection<ISong> Songs
		{
			get { return songs.AsReadOnly(); }
		}

		public void AddPerformer(IPerformer performer) => this.performers.Add(performer);

		public void AddSong(ISong song)
		{
			if (song.Duration + this.ActualDuration > this.MaxDuration)
			{
				throw new InvalidOperationException("Song is over the set limit!");
			}

			this.songs.Add(song);
		}

		public bool CanPerform()
		{
			if (!this.performers.Any())
			{
				return false;
			}

			if (!this.songs.Any())
			{
				return false;
			}

			var allPerformersHaveInstruments = this.performers.All(p => p.Instruments.Any());

			if (!allPerformersHaveInstruments)
			{
				return false;
			}

			var allPerformersHaveFunctioningInstruments = this.performers.All(p => p.Instruments.Any(i => !i.IsBroken));

			if (!allPerformersHaveFunctioningInstruments)
			{
				return false;
			}

			return true;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.AppendLine(string.Join(", ", this.Performers));

			foreach (var song in this.Songs)
			{
				sb.AppendLine($"-- {song}");
			}

			var result = sb.ToString();
			return result;
		}
	}
}
