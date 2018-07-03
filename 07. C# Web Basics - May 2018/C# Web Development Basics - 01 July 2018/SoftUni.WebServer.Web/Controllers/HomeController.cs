namespace SoftUni.WebServer.Web.Controllers
{
    using SoftUni.WebServer.Models;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {           
            if (this.User.IsAuthenticated)
            {
                ICollection<Product> products = new List<Product>();
                using (this.Context)
                {
                    products = this.Context
                        .Products
                        .Select(p => p)
                        .ToList();
                }

                var builder = new StringBuilder();
                builder.Append($@"
                                <main class=""mt-3 mb-5"">
                                <div class=""container-fluid text-center"">
                                <h2>Greetings, 
                                    {this.User.Name}!</h2>
                                    <h4>Feel free to view and order any of our products.</h4>
                                </div>
                                <hr class=""hr-2 bg-dark""/>
                                <div class=""container-fluid product-holder"">
                                <div class=""row d-flex justify-content-around"">
                              ");

                int i = 1;
                foreach (var product in products)
                {
                    var description = string.Empty;

                    if (product.Description.Length >= 50)
                    {
                        product.Description = product.Description.Substring(0, 50) + "...";
                    }

                    builder.Append($@"
                                    <a href = ""/products/details?id={product.Id}"" class=""col-md-2"">
                                        <div class=""product p-1 chushka-bg-color rounded-top rounded-bottom"">
                                            <h5 class=""text-center mt-3"">{product.Name}</h5>
                                            <hr class=""hr-1 bg-white""/>
                                            <p class=""text-white text-center"">
                                                {product.Description}
                                            </p>
                                            <hr class=""hr-1 bg-white""/>
                                            <h6 class=""text-center text-white mb-3"">$500</h6>
                                        </div>
                                    </a>");

                    if (i % 5 == 0)
                    {
                        builder.Append(@"</div></div><div class=""row"" style=""margin-top:10px;""></div><div class=""container-fluid product-holder""><div class=""row d-flex justify-content-around"">");
                    }

                    i++;
                }

                builder.Append($@"
                                </div>
                                </div>                                
                                </main>
                                ");

                this.ViewData.Data["homeContent"] = builder.ToString();
            }
            else
            {
                this.ViewData.Data["homeContent"] =
                    @"<main>
                    <div class=""jumbotron mt-3 chushka-bg-color"">
                            <h1> Welcome to Chushka Universal Web Shop </h1>
                            <hr class=""bg-white"" />
                        <h3><a class=""nav-link-dark"" href=""/users/login"">Login</a> if you have an account.</h3>
                        <h3><a class=""nav-link-dark"" href=""/users/register"">Register</a> if you don't.</h3>
                    </div>
                    </main>";
            }
            return this.View();
        }
    }
}
