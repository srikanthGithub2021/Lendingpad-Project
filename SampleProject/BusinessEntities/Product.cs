using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BusinessEntities
{
    public class Product: IdObject
    {
        private string _productName;
        private string _description;
        private decimal? _price;
        private ProductCategory _category;
        private int _stockQuantity;
        private bool _isActive;



        public string ProductName
        {
            get => _productName;
            private set => _productName = value;
        }

        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        public decimal? Price
        {
            get => _price;
            private set => _price = value;
        }

        public ProductCategory category
        {
            get => _category;
            private set => _category = value;
        }

        public int StockQuantity
        {
            get => _stockQuantity;
            private set => _stockQuantity = value;
        }

        public bool IsActive
        {
            get => _isActive;
            private set => _isActive = value;
        }

        public void SetProductName(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException("productName was not provided.");
            }
            _productName = productName;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("description was not provided.");
            }
            _description = description;
        }

        public void SetPrice(decimal? price)
        {
            _price = price;
        }

        public void SetStockQuantity(int stockQuantity)
        {
            _stockQuantity = stockQuantity;
        }

 

        public void SetCategory(ProductCategory category)
        {
            _category=category;
        }

        public void SetIsActive(bool isActive)
        {
         
            _isActive = isActive;
        }

        public void ReduceStock(int qty)
        {
            if(qty<=0)
            {
                throw new ArgumentException("Quantity must be greater than zero");

            }
            if(_stockQuantity<qty)
            {
                throw new InvalidOperationException("Insufficent stock for the product you seleted");
            }
            _stockQuantity -= qty;
        }

    }


}
