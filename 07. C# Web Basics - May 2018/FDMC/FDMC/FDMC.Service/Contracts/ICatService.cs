namespace FDMC.Service.Contracts
{
    using Models;
    using System.Collections.Generic;
    public interface ICatService
    {
        IEnumerable<CatModel> All();

        void Add(CatModel model);

        CatModel ById(int id);
    }
}
