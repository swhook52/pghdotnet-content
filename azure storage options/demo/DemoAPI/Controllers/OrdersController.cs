using DemoAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class OrdersController : ApiController
    {


        public async Task<IEnumerable<Models.Order>> Get()
        {
            List<Models.Order> result = new List<Models.Order>();

            using(var db = new NorthwindEntities())
            {
                await db.Database.Connection.OpenAsync();
                foreach (var order in db.Orders.Take(20))
                {
                    result.Add(Models.Order.FromDBOrder(order));
                }
            }

            return result;
        }

    }
}
