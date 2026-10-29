using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class Order:IdObject
    {
        private readonly List<OrderItem> _items=new List<OrderItem>();
        private Guid _customerId;
        private string _customerName;
        private OrderStatus _status;
        private DateTime _created;
        private string _notes;

        public Guid CustomerId { get => _customerId; set => _customerId = value; }
        public string CustomerName { get => _customerName; set => _customerName = value; }
        public OrderStatus Status { get => _status; set => _status = value; }
        public DateTime Created { get => _created; set => _created = value; }
        public string Notes { get => _notes; set => _notes = value; }

        public List<OrderItem> Items { get => _items; set =>_items.Initialize(value); }


        public decimal TotalAmount => _items.Sum(i => i.LineTotal);


        public Order()
        {
            _created = DateTime.UtcNow;
            _status = OrderStatus.Pending;
        }

        public void SetStatus(OrderStatus status)

        {

            this._status = status;
        }
        public void SetCustomerName(string customerName)

        {
            if (string.IsNullOrEmpty(customerName))
            {
                throw new ArgumentNullException("customerName was not provided.");
            }
            this._customerName = customerName;
        }

        public void SetCustomerId(Guid customerId)

        {
           
            this._customerId = customerId;
        }
        public void SetNotes(string notes)

        {

            this._notes = notes;
        }
        public void SetItems(IEnumerable<OrderItem> items)

        {

            _items.Initialize(items);
        }
    }
}
