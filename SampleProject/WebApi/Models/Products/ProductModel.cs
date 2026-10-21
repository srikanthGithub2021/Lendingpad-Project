using BusinessEntities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApi.Models.Products
{
    public  class ProductModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public ProductCategory Category { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}