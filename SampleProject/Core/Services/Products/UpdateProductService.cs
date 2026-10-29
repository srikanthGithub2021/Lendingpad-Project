using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class UpdateProductService:IUpdateProductService
    {
        public void Update(Product product, string productName, string description, decimal? price, ProductCategory category, int StockQuantity, bool isActive=false)
        {
            product.SetProductName(productName);
            product.SetDescription(description);
            product.SetPrice(price);
            product.SetCategory(category);
            product.SetStockQuantity(StockQuantity);
            product.SetIsActive(isActive);
        }
    }
}
