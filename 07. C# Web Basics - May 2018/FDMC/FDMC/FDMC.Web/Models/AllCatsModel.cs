namespace FDMC.Web.Models
{
    using FDMC.Service.Models;
    using System.Collections.Generic;
    public class AllCatsModel
    {
        public IEnumerable<CatModel> All { get; set; }
    }
}
