using BusinessEntities;
using Core.Services.Orders;
using Raven.Abstractions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController:BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId,[FromBody] OrderModel model)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order != null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"order already exist for orderId: {orderId}");
            }
            var items = model.Items.Select(i =>
            {
                var item = new OrderItem();
                item.SetProductId(i.ProductId);
                item.SetProductName(i.ProductName);
                item.SetQuantity(i.Quantity);
                item.SetUnitPrice(i.UnitPrice);
                return item;

            }
            ).ToList();

             order = _createOrderService.Create(orderId,model.CustomerId, model.CustomerName, items, model.Notes);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            var items = model.Items.Select(i =>
            {
                var item = new OrderItem();
                item.SetProductId(i.ProductId);
                item.SetProductName(i.ProductName);
                item.SetQuantity(i.Quantity);
                item.SetUnitPrice(i.UnitPrice);
                return item;

            }
            ).ToList();

            _updateOrderService.Update(order, model.CustomerId, model.CustomerName, items, model.Notes);
            return Found(new OrderData(order));
        }


        [Route("list")]
        [HttpGet]

        public HttpResponseMessage GetOrders(int skip, int take)
        {
            var orders=_getOrderService.GetOrders().Skip(skip).Take(take)
                .Select(o=>new OrderData(o)).ToList();
      
         

            return Found(orders);
        }
        [Route("{orderId:guid}/delete")]
        [HttpDelete]

        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            
           
            if (order == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"No order found for orderId: {orderId}");
            }
        
            
            return Found();

            
        }

        [Route("clear")]
        [HttpDelete]

        public HttpResponseMessage DeleteAllOrders()
        {
            _deleteOrderService.DeleteAll(confirm: true);

            return Found();


        }
        [Route("{orderId:guid}")]
        [HttpGet]

        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);


            if (order == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"No order found for orderId: {orderId}");
            }

            return Found(order);


        }
    }
}