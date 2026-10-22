using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(Order order, Guid customerId, string customerName, IEnumerable<OrderItem> items, string notes)
        {
            order.SetCustomerId(customerId);
            order.SetCustomerName(customerName);
            order.SetItems(items);
            order.SetNotes(notes);

        }

        public void UpdateStatus(Order order, OrderStatus status)
        {
            order.SetStatus(status);
        }
    }
}
