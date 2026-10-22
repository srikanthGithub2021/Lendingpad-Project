using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface  ICreateOrderService
    {
        Order Create(Guid customerId,string customerName,IEnumerable<OrderItem> items,string notes);
       
    }
}
