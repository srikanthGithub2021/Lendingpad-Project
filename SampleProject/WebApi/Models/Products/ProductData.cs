using BusinessEntities;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApi.Models.Products
{
    public class ProductData:IdObjectData
    {
        public ProductData(Product product): base(product)
        {
            ProductName=product.ProductName;
            Description=product.Description;
            Price=product.Price;
            Category=new EnumData(product.category);
            StockQuantity=product.StockQuantity;
            IsActive=product.IsActive;

        }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }  
        public EnumData Category { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}