using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;


namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Order GetOrder(Guid id)
        {
            if (id == Guid.Empty)
            { 
            throw new ArgumentException("Order id should not be empty .");
            }

            var order =  ((IRepository<Order>)_orderRepository).Get(id);

            if (order == null)
                throw new KeyNotFoundException("Order not found");

            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
