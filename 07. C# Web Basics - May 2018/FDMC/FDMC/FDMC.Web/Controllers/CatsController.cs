namespace FDMC.Web.Controllers
{
    using FDMC.Service.Contracts;
    using FDMC.Service.Models;
    using FDMC.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    public class CatsController : Controller
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService)
        {
            this.catService = catService;
        }

        public IActionResult Index()
        {
            var cats = this.catService.All();

            return View(new AllCatsModel
            {
                All = cats
            });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CatAddingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.catService.Add(new CatModel
            {
                 Name = model.Name,
                 Breed = model.Breed,
                 Age = (int)model.Age,
                 Url = model.Url
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ById(int id)
        {
            var cat = this.catService.ById(id);

            return View(new CatAddingModel
                {
                    Name = cat.Name,
                    Breed = cat.Breed,
                    Age = cat.Age,
                    Url = cat.Url
                });
        }
    }
}