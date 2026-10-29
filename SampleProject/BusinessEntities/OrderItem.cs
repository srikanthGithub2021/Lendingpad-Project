using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class OrderItem
    {
        private Guid _productId;
        private string _productName;
        private int _quantity;
        private decimal _unitPrice;

        public Guid ProductId
        {
            get => _productId;
            private set => _productId = value;
        }
        public string ProductName
        {
            get => _productName;
            private set => _productName = value;
        }

        public int Quantity
        {
            get => _quantity;
            private set => _quantity = value;
        }
        public decimal UnitPrice
        {
            get => _unitPrice;
            private set => _unitPrice = value;
        }

        public void SetProductId(Guid productId)
        { this._productId = productId; }

        public decimal LineTotal => _quantity * _unitPrice;

        public void SetProductName(string productName)

        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException("productName was not provided.");
            }
            this._productName = productName; 
        }
        public void SetQuantity(int quantity)
        {
            if (quantity<=0)
            {
                throw new ArgumentException("quantity must be greater thean zero.");
            }
            this._quantity = quantity;
        }
        public void SetUnitPrice(decimal unitPrice)
        {
            if (unitPrice < 0)
            {
                throw new ArgumentException("unitPrice shoud not be negative.");
            }
            this._unitPrice = unitPrice;
        }

    }
}
