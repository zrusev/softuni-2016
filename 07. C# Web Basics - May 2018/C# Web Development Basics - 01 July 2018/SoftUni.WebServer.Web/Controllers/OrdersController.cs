using Microsoft.EntityFrameworkCore;
using SoftUni.WebServer.Models;
using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
using SoftUni.WebServer.Mvc.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUni.WebServer.Web.Controllers
{
    public class OrdersController :BaseController
    {
        public ICollection Orders { get; private set; }

        [HttpGet]
        public IActionResult All()
        {
            if (this.User.IsInRole(Constants.UserRole))
            {
                return RedirectToHome();
            }

            ICollection<Order> orders = new List<Order>();

            using (this.Context)
            {
                orders = this.Context
                    .Orders
                    .Include(s => s.Client)
                    .Include(p => p.Product)
                    .Select(o => o)
                    .ToList();
            }

            int i = 1;
            var builder = new StringBuilder();
            foreach (var order in orders)
            {
                builder.Append( $@"
                                    <tr>
                                        <th scope=""row"">{i}</th>
                                        <td>{order.Id}</td>
                                        <td>{order.Client.Username}</td>
                                        <td>{order.Product.Name}</td>
                                        <td>{order.OrderedOn.ToShortDateString()}</td>
                                    </tr>
                                ");
                i++;
            }

            this.ViewData.Data["body"] = builder.ToString();

            return this.View();
        }
    }
}
