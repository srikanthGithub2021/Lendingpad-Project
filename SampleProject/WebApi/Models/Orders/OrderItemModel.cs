
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApi.Models.Orders
{
    public  class OrderItemModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName { get; set; }
    }
}