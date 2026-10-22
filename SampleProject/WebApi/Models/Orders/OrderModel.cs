
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApi.Models.Orders
{
    public  class OrderModel
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItemData> Items { get; set; }
        public string Notes { get; set; }
    }
}