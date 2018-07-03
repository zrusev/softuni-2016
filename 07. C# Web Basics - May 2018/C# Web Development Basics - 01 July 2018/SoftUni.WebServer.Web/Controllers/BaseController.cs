namespace SoftUni.WebServer.Web.Controllers
{
    using SoftUni.WebServer.Data;
    using SoftUni.WebServer.Mvc.Controllers;
    using SoftUni.WebServer.Mvc.Interfaces;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Context = new WebServerContext();
        }
        
        protected WebServerContext Context { get; set; }

        protected IActionResult RedirectToHome() => this.RedirectToAction("/home/index");

        public override void OnAuthentication()
        {
            if (this.User.IsAuthenticated && this.User.IsInRole(Constants.AdminRole))
            {
                this.ViewData.Data["topMenu"] =
                @"<li class=""nav-item"">
                    <a class=""nav-link nav-link-white"" href=""/"">Home</a>
                  </li>
                  <li class=""nav-item"">
                    <a class=""nav-link nav-link-white"" href=""/products/create"">Create Product</a>
                  </li>
                  <li class=""nav-item"">
                    <a class=""nav-link nav-link-white"" href=""/orders/all"">All Orders</a>
                  </li>
                  <li class=""nav-item"">
                    <a class=""nav-link nav-link-white"" href=""/users/logout"">Logout</a>
                  </li>";
            }
            else if (this.User.IsAuthenticated && this.User.IsInRole(Constants.UserRole))
            {
                this.ViewData.Data["topMenu"] =
                @"<li class=""nav-item"">
                    <a class=""nav-link nav-link-white"" href=""/"">Home</a>
                  </li>
                  <li class=""nav-item"">
                    <a class=""nav-link nav-link-white"" href=""/users/logout"">Logout</a>
                  </li>";
            }
            else
            {
                this.ViewData.Data["topMenu"] =
                @"<li class=""nav-item"">
                    <a class=""nav-link nav-link-white"" href=""/"">Home</a>
                  </li>
                  <li class=""nav-item"">
                    <a class=""nav-link nav-link-white"" href=""/users/login"">Login</a>
                  </li>
                  <li class=""nav-item"">
                    <a class=""nav-link nav-link-white"" href=""/users/register"">Register</a>
                  </li>";
            }
            
            base.OnAuthentication();
        }
    }
}
