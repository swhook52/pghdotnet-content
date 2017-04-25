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
    public class TableOrdersController : ApiController
    {

        [HttpGet, Route("api/tableorders/seed")]
        public async Task<IHttpActionResult> Seed()
        {

            var tableClient = Tables.GetClient();

            using (var db = new NorthwindEntities())
            {
                await db.Database.Connection.OpenAsync();
                foreach (var order in db.Orders)
                {
                    var tableOrder = Models.Order.FromDBOrder(order);
                    tableOrder.RowKey = Guid.NewGuid().ToString();
                    tableOrder.PartitionKey = order.ShipCountry;
                    await Tables.AddEntity(tableClient, "Orders", tableOrder);
                      
                }
            }

            return Ok();   
        }

        public IEnumerable<Models.Order> Get()
        {
            var tableClient = Tables.GetClient();

            return Tables.GetAll<Models.Order>(tableClient, "Orders");
        }
    }
}
