using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class Order : TableEntity
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<int> ShipVia { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public static Order FromDBOrder(Data.Order from)
        {
            return new Order()
            {
                CustomerId = from.CustomerID,
                EmployeeId = from.EmployeeID,
                EmployeeName = from.EmployeeName,
                OrderDate = from.OrderDate, 
                RequiredDate = from.RequiredDate,
                ShippedDate = from.ShippedDate,
                ShipVia = from.ShipVia,
                Freight = from.Freight,
                ShipName = from.ShipName,
                ShipAddress = from.ShipAddress,
                ShipCity = from.ShipCity,
                ShipRegion = from.ShipRegion,
                ShipPostalCode = from.ShipPostalCode,
                ShipCountry = from.ShipCountry,
                OrderId = from.OrderID
            };
        }

    }

}