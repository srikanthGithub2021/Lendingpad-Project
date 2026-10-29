using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class DeleteOrderService : IDeleteOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Delete(Order order)
        {
           _orderRepository.Delete(order);
        }

        public void DeleteAll(bool confirm = false)
        {
           if(!confirm)
            {
                throw new InvalidOperationException("Delete all required confiramtion.");
            }
            _orderRepository.DeleteAll();
        }
    }
}
