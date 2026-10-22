using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public  class CreateOrderService: ICreateOrderService
    {
        private readonly IIdObjectFactory<Order> _orderfactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUpdateOrderService _updateOrderService;

        public CreateOrderService(IIdObjectFactory<Order> orderfactory, IOrderRepository orderRepository, IProductRepository productRepository, IUpdateOrderService updateOrderService)
        {
            _orderfactory = orderfactory;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _updateOrderService = updateOrderService;
        }

        public Order Create(Guid id, Guid customerId, string customerName, IEnumerable<OrderItem> items, string notes)
        {
            if(items==null||items.ToList().Count==0)
            {
                throw new ArgumentNullException(nameof(items));
            }
           
           var itemsList= items.ToList();
            if(!itemsList.Any())
            {
                throw new ArgumentException("Order must contain a item");
            }

            var products = new List<(Product Product, int OrderQty)>();
            foreach( var item in itemsList)
            {
                var product = _productRepository.Get(item.ProductId);
                if (product == null)
                {
                    throw new KeyNotFoundException($"product with id '{item.ProductId}' was not found");
                }
                products.Add((product, item.Quantity));

            }

            foreach ( var(product,orderqty) in products)
            {
                product.ReduceStock(orderqty);
                _productRepository.Save(product);
            }

           
            var order= _orderfactory.Create(id);
            _updateOrderService.Update(order,customerId,customerName,itemsList,notes    );
            _orderRepository.Save(order);
            return order;
        }
    }
}
