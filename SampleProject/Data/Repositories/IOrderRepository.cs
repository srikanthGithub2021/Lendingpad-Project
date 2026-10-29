using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        IEnumerable<Order> Get(Guid? customerId=null,OrderStatus? status=null);
        void DeleteAll();
    }
}
