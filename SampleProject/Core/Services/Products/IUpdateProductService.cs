using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IUpdateProductService
    {
        void Update(Product product, string productName, string description, decimal? price, ProductCategory category, int StockQuantity, bool isActive);
    }
}
