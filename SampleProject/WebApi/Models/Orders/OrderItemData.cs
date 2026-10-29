
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApi.Models.Orders
{
    public class OrderItemData
    {
        public OrderItemData(OrderItem item)
        {
            ProductId= item.ProductId;
            ProductName= item.ProductName;
            Quantity= item.Quantity;
            UnitPrice= item.UnitPrice;
            LineTotal= item.LineTotal;
        }

        public Guid ProductId { get;  set; }
        public int Quantity { get;  set; }
        public decimal UnitPrice { get;  set; }
        public decimal LineTotal { get;  set; }
        public string ProductName { get;  set; }
    }
}