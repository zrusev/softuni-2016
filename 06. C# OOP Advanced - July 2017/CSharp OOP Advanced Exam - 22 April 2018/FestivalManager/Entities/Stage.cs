namespace FestivalManager.Entities
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Stage : IStage
    {
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;
        public IReadOnlyCollection<ISong> Songs => this.songs;
        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer currentPerformer = this.performers.Where(p => p.Name == name).FirstOrDefault();
            return currentPerformer;
        }

        public ISet GetSet(string name)
        {
            ISet currentSet = this.sets.Where(s => s.Name == name).FirstOrDefault();
            return currentSet;
        }

        public ISong GetSong(string name)
        {
            ISong currentSong = this.songs.Where(s => s.Name == name).FirstOrDefault();
            return currentSong;
        }

        public bool HasPerformer(string name)
        {
            bool hasAny = this.performers.Any(p => p.Name == name);
            return hasAny;
        }

        public bool HasSet(string name)
        {
            bool hasAny = this.sets.Any(p => p.Name == name);
            return hasAny;
        }

        public bool HasSong(string name)
        {
            bool hasAny = this.songs.Any(p => p.Name == name);
            return hasAny;
        }
    }
}