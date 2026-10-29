using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        void Update(Order order, Guid customerId, string customerName, IEnumerable<OrderItem> items, string notes);

        void UpdateStatus(Order order, OrderStatus status);
    }
}
