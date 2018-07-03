namespace SoftUni.WebServer.Web.Attributes
{
    using SoftUni.WebServer.Http.Interfaces;
    using SoftUni.WebServer.Mvc.Attributes.Security;
    public class AuthorizeLoginAttribute : AuthorizeAttribute
    {
        public override IHttpResponse GetResponse(string message)
        {
            return base.GetResponse(message);
        }
    }
}
