using DemoAPI.DocumentDB;
using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class DBOrdersController : ApiController
    {
        //public async Task<IEnumerable<Order>> Get()
        //{
        //    var client = DocDB.GetClient();
        //    await client.OpenAsync();

        //    var query = DocDB.GetAll<Order>(client, "Orders");

        //    return query.AsEnumerable();

        //}

        public async Task<IEnumerable<Order>> Get()
        {
            var client = DocDB.GetClient();
            await client.OpenAsync();

            var sql = @"
                SELECT 
                        c.CustomerID, 
                        c.Customer.Orders.OrderID,
                        c.Customer.Orders.EmployeeID,
                        c.Customer.Orders.OrderDate,
                        c.Customer.Orders.RequiredDate,
                        c.Customer.Orders.ShippedDate,
                        c.Customer.Orders.ShipVia,
                        c.Customer.Orders.Freight,
                        c.Customer.Orders.ShipName,
                        c.Customer.Orders.ShipAddress,
                        c.Customer.Orders.ShipCity,
                        c.Customer.Orders.ShipRegion,
                        c.Customer.Orders.ShipPostalCode,
                        c.Customer.Orders.ShipCountry
                FROM c";

            var query = DocDB.GetSQLQuery<Order>(client, "Orders", sql);

            return query.AsEnumerable();
        }
    }
}
