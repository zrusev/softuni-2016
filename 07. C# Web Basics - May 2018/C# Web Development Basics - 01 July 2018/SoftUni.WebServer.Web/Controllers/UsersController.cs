namespace SoftUni.WebServer.Web.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using Models.BindingModels;
    using SoftUni.WebServer.Common;
    using SoftUni.WebServer.Models;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersController : BaseController
    {        
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisteringModel model)
        {
            if (!this.IsValidModel(model))
            {
                return this.View();
            }

            var user = new User()
            {
                Username = model.Username,
                FullName = model.FullName,
                Email = model.Email,
                PasswordHash = PasswordUtilities.GetPasswordHash(model.Password)
            };
            
            using (this.Context)
            {
                user.Role = this.Context
                        .Roles
                        .Where(r => r.RoleName == Constants.UserRole)
                        .Select(r => r)
                        .FirstOrDefault();

                this.Context.Users.Add(user);
                this.Context.SaveChanges();
                this.SignIn(user.Username, user.Id, new List<string>() { user.Role.RoleName });
            }

            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Login()
        {
            this.ViewData.Data["error"] = string.Empty;
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoggingInModel model)
        {
            var user = this.Context
                .Users
                .Include(r => r.Role)
                .Where(u => u.Username == model.Username)
                .Select(u => u)
                .FirstOrDefault();

            if (user == null)
            {
                this.ViewData.Data["error"] = "Invalid username and / or password";
                return this.View();
            }

            string passwordHash = PasswordUtilities.GetPasswordHash(model.Password);
            if (user.PasswordHash != passwordHash)
            {
                this.ViewData.Data["error"] = "Invalid username and / or password";
                return this.View();
            }

            this.SignIn(user.Username, user.Id, new List<string>() { user.Role.RoleName });
            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToHome();
        }
    }
}
