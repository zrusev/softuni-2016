namespace SoftUni.WebServer.Web.Controllers
{
    using SoftUni.WebServer.Models;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;
    using SoftUni.WebServer.Web.Models.BindingModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ProductsController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            ICollection<ProductType> productTypes = new List<ProductType>();
            using (this.Context)
            {
                productTypes = this.Context
                    .ProductTypes
                    .Select(p => p).ToList();
            }

            var builder = new StringBuilder();
            foreach (var type in productTypes)
            {
                builder.Append($@"<label class=""radio-inline"">
                                    <input type=""radio"" name=""ProductType"" value=""{type.Id}""> {type.Type}
                               </label>");
            }

            this.ViewData.Data["productTypes"] = builder.ToString();

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
            if (!this.IsValidModel(model))
            {
                return this.View();
            }

            int productId;
            bool result = int.TryParse(model.ProductType, out productId);

            if (!result)
            {
                return this.View();
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description
            };

            using (this.Context)
            {
                product.ProductType = this.Context
                    .ProductTypes
                    .Where(p => p.Id == productId)
                    .Select(p => p)
                    .FirstOrDefault();

                this.Context.Products.Add(product);
                this.Context.SaveChanges();
            }
            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Product product;
            string type = string.Empty;

            using (this.Context)
            {
                product = this.Context
                    .Products
                    .Where(i => i.Id == id)
                    .Select(p => p)
                    .FirstOrDefault();

                type = this.Context
                    .ProductTypes
                    .Where(t => t.Id == 1)
                    .Select(n => n.Type)
                    .FirstOrDefault();
            }

            if (product == null)
            {
                return this.RedirectToHome();
            }

            this.ViewData.Data["id"] = id.ToString();
            this.ViewData.Data["name"] = product.Name;
            this.ViewData.Data["price"] = product.Price.ToString();
            this.ViewData.Data["description"] = product.Description;
            this.ViewData.Data["type"] = type;
            this.ViewData.Data["admin"] = string.Empty;

            if (this.User.IsInRole(Constants.AdminRole))
            {
                this.ViewData.Data["admin"] = $@"
                                               <div class=""product-action-holder mt-4 d-flex justify-content-around"">
                                                    <a class=""btn chushka-bg-color"" href=""/products/edit?id={product.Id}"">Edit</a>
                                               </div>
                                               <div class=""product-action-holder mt-4 d-flex justify-content-around"">
                                                    <a class=""btn chushka-bg-color"" href=""/products/delete?id={product.Id}"">Delete</a>
                                               </div>";
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product;
            string type = string.Empty;
            ICollection<ProductType> productTypes = new List<ProductType>();

            using (this.Context)
            {
                productTypes = this.Context
                    .ProductTypes
                    .Select(p => p)
                    .ToList();

                product = this.Context
                    .Products
                    .Where(i => i.Id == id)
                    .Select(p => p)
                    .FirstOrDefault();

                type = this.Context
                    .ProductTypes
                    .Where(t => t.Id == 1)
                    .Select(n => n.Type)
                    .FirstOrDefault();
            }

            if (product == null)
            {
                return this.RedirectToHome();
            }

            this.ViewData.Data["id"] = product.Id.ToString();
            this.ViewData.Data["name"] = product.Name;
            this.ViewData.Data["price"] = product.Price.ToString();
            this.ViewData.Data["description"] = product.Description;

            var builder = new StringBuilder();
            foreach (var typeProduct in productTypes)
            {
                if (typeProduct.Id == product.ProductType.Id)
                {
                    builder.Append($@"<label class=""radio-inline"">
                                    <input type=""radio"" name=""ProductType"" value=""{typeProduct.Id}"" checked=""checked""> {typeProduct.Type}
                               </label>");
                }
                else
                {
                    builder.Append($@"<label class=""radio-inline"">
                                    <input type=""radio"" name=""ProductType"" value=""{typeProduct.Id}""> {typeProduct.Type}
                               </label>");
                }
            }

            this.ViewData.Data["productTypes"] = builder.ToString();

            return this.View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product;
            string type = string.Empty;
            ICollection<ProductType> productTypes = new List<ProductType>();

            using (this.Context)
            {
                productTypes = this.Context
                    .ProductTypes
                    .Select(p => p).ToList();

                product = this.Context
                    .Products
                    .Where(i => i.Id == id)
                    .Select(p => p)
                    .FirstOrDefault();

                type = this.Context
                    .ProductTypes
                    .Where(t => t.Id == product.ProductType.Id)
                    .Select(n => n.Type)
                    .FirstOrDefault();
            }

            if (product == null)
            {
                return this.RedirectToHome();
            }

            this.ViewData.Data["id"] = product.Id.ToString();
            this.ViewData.Data["name"] = product.Name;
            this.ViewData.Data["price"] = product.Price.ToString();
            this.ViewData.Data["description"] = product.Description;

            var builder = new StringBuilder();
            foreach (var typeProduct in productTypes)
            {
                if (typeProduct.Id == product.ProductType.Id)
                {
                    builder.Append($@"<label class=""radio-inline"">
                                    <input type=""radio"" name=""ProductType"" value=""{typeProduct.Id}"" checked=""checked"" disabled> {typeProduct.Type}
                               </label>");
                }
                else
                {
                    builder.Append($@"<label class=""radio-inline"">
                                    <input type=""radio"" name=""ProductType"" value=""{typeProduct.Id}"" disabled> {typeProduct.Type}
                               </label>");
                }
            }

            this.ViewData.Data["productTypes"] = builder.ToString();
            
            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(DeleteProductModel model)
        {
            if (this.User.IsInRole(Constants.UserRole))
            {
                return RedirectToHome();
            }

            using (this.Context)
            {
                var product = this.Context
                    .Products
                    .Where(i => i.Id == model.Id)
                    .Select(p => p)
                    .FirstOrDefault();

                if (product == null)
                {
                    return RedirectToHome();
                }

                this.Context.Products.Remove(product);
                this.Context.SaveChanges();
            }

            return this.RedirectToHome();
        }

        [HttpPost]
        public IActionResult Edit(EditProductModel model)
        {
            int productId;
            bool result = int.TryParse(model.ProductType, out productId);

            if (!result)
            {
                return this.View();
            }

            Product product;
            using (this.Context)
            {
                product = this.Context
                    .Products
                    .Where(p => p.Id == model.Id)
                    .Select(a => a)
                    .FirstOrDefault();

                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;

                product.ProductType = this.Context
                    .ProductTypes
                    .Where(t => t.Id == productId)
                    .Select(p => p)
                    .FirstOrDefault();

                this.Context.Products.Update(product);
                this.Context.SaveChanges();
            }
            return this.RedirectToHome();
        }
   
        public IActionResult Order(string id)
        {

            if (id == string.Empty)
            {
                return RedirectToHome();
            }

            using (this.Context)
            {
                var client = this.Context
                    .Users
                    .Where(u => u.Id == this.User.Id)
                    .FirstOrDefault();

                var order = new Order
                {
                    OrderedOn = DateTime.Now,
                    Client = client
                };

                order.Product = this.Context
                    .Products
                    .Where(p => p.Id == int.Parse(id))
                    .Select(p => p)
                    .FirstOrDefault();

                this.Context.Orders.Add(order);
                this.Context.SaveChanges();
            }

            return this.RedirectToHome();
        }
    }
}