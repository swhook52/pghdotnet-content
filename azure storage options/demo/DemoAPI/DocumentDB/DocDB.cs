using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.DocumentDB
{
    public class DocDB
    {
        private const string EndpointUrl = "<from_portal>";
        private const string PrimaryKey = "<from_portal>";


        public static DocumentClient GetClient()
        {
            return new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
        }

        public static IQueryable<T> GetAll<T>(DocumentClient client, string collectionName)
        {
            Uri docLink = UriFactory.CreateDocumentCollectionUri("CustomerOrders", collectionName);
            return client.CreateDocumentQuery<T>(docLink);
        }

        public static IQueryable<T> GetSQLQuery<T>(DocumentClient client, string collectionName, string sql)
        {
           Uri docLink = UriFactory.CreateDocumentCollectionUri("CustomerOrders", collectionName);
           return client.CreateDocumentQuery<T>(docLink, sql);
        }


        //var sql = @"
        //        SELECT 
        //                c.CustomerID, 
        //                c.Customer.Orders.OrderID,
        //                c.Customer.Orders.EmployeeID,
        //                c.Customer.Orders.OrderDate,
        //                c.Customer.Orders.RequiredDate,
        //                c.Customer.Orders.ShippedDate,
        //                c.Customer.Orders.ShipVia,
        //                c.Customer.Orders.Freight,
        //                c.Customer.Orders.ShipName,
        //                c.Customer.Orders.ShipAddress,
        //                c.Customer.Orders.ShipCity,
        //                c.Customer.Orders.ShipRegion,
        //                c.Customer.Orders.ShipPostalCode,
        //                c.Customer.Orders.ShipCountry
        //        FROM c";
    }
}