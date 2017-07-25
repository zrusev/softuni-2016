using System.Collections.Generic;

namespace Military_Elite.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        IList<IMissions> Missions { get; }

        void CompleteMission();
    }
}