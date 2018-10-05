namespace FDMC.Service.Implementations
{
    using Contracts;
    using FDMC.Data.Context;
    using FDMC.Data.Models;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CatService : ICatService
    {
        private readonly FdmcContext db;

        public CatService(FdmcContext db)
        {
            this.db = db;
        }

        public void Add(CatModel model)
        {
            this.db.Add(new Cat
            {
                Name = model.Name,
                Breed = model.Breed,
                Age = model.Age,
                Url = model.Url
            });

            this.db.SaveChanges();
        }

        public IEnumerable<CatModel> All()
            => this.db
                    .Cats
                    .Select(c => new CatModel
                    {
                         Id = c.Id,
                         Name = c.Name,
                         Breed = c.Breed,
                         Age = c.Age,
                         Url = c.Url
                    })
                    .ToList();

        public CatModel ById(int id)
            => this.db
            .Cats
            .Where(c => c.Id == id)
            .Select(cat => new CatModel
            {
                Name = cat.Name,
                Breed = cat.Breed,
                Age = cat.Age,
                Url = cat.Url
            })
            .FirstOrDefault();
    }
}
