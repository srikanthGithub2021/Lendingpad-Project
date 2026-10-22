using BusinessEntities;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : InMemoryRepository<Order>, IOrderRepository
    {
        public OrderRepository(IInMemoryStorage<Order> storage) : base(storage)
        {
        }

        public void DeleteAll()
        {
            var orders = Storage.GetAll().ToList();
            foreach (var order in orders)
            {
                Storage.Delete(order);
            }
        }

        public IEnumerable<Order> Get(Guid? customerId = null, OrderStatus? status = null)
        {
            var query = Storage.GetAll();
            if (customerId != null)
            {
                query=query.Where(o=> o.CustomerId == customerId);
            }
            if(status!=null)
            {
                query = query.Where(o => o.Status == status);

            }

            return query.ToList();
        }
    }
}
