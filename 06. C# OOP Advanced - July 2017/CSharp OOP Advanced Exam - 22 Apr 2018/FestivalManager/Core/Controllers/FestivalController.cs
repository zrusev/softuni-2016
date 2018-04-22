namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;
    using System;
    using System.Globalization;
    using System.Linq;
    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
        private const string TimeAccumulatedFormat = "{0:00}:{1:00}";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private static CultureInfo provider = CultureInfo.InvariantCulture;
        private readonly IStage stage;

        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;
        private ISongFactory songFactory;

		public FestivalController(IStage stage)
		{
            this.stage = stage;

            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
        }

		public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

			foreach (var set in this.stage.Sets)
			{
                result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({FormatTime(song.Duration)})") + "\n";
					}
				}
			}

			return result.ToString();
		}

        private string FormatTime(TimeSpan ts)
        {
            int mins = (ts.Days * 1440) + (ts.Hours * 60) + ts.Minutes;
            int secs = ts.Seconds;

            return $"{mins:D2}:{secs:D2}";
        }

        public string RegisterSet(string[] args)
		{
            ISet set = this.setFactory.CreateSet(args[0], args[1]);
            this.stage.AddSet(set);

            return $"Registered {args[1]} set";
		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var performer = this.performerFactory.CreatePerformer(name, age);

            var instruments = args.Skip(2)
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            foreach (var instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, provider);

            ISong song = this.songFactory.CreateSong(args[0], duration);
            this.stage.AddSong(song);

            return $"Registered song {args[0]} ({args[1]})";
        }

		public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song} to {set.Name}";
		}

		public string AddPerformerToSet(string[] args)
		{
			return PerformerRegistration(args);
		}

		private string PerformerRegistration(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return $"Added {performer.Name} to {set.Name}";
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
	}
}