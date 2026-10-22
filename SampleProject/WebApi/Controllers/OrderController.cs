using BusinessEntities;
using Core.Services.Orders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [Route("{customerId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid customerId,[FromBody] OrderModel model)
        {
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

            var order = _createOrderService.Create(customerId, model.CustomerName, items, model.Notes);
            return Found(new OrderData(order));
        }

    }
}