
using BusinessEntities;
using Raven.Abstractions.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace WebApi.Models.Orders
{
    public class OrderData: IdObjectData
    {
        public OrderData(Order order):base (order) 
        {
            CustomerId = order.CustomerId;
            CustomerName=order.CustomerName;
            Status=new EnumData(order.Status);
            Items=order.Items.Select(i=> new OrderItemData(i)).ToList();
            TotalAmount=order.TotalAmount;
            Created=order.Created;
            Notes=order.Notes;

        }

        public Guid CustomerId { get;  set; }
        public string CustomerName { get;  set; }
        public EnumData Status { get;  set; }
        public List<OrderItemData> Items { get;  set; }
        public decimal TotalAmount { get;  set; }
        public DateTime Created { get;  set; }
        public string Notes { get;  set; }
    }
}