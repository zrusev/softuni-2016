using System.Collections.Generic;

namespace Military_Elite.Interfaces
{
    public interface ILeutenantGeneral : IPrivate
    {
        IList<ISoldier> Soldiers { get; }
    }
}