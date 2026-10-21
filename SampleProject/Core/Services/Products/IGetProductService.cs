using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);

        IEnumerable<Product> GetProducts(string productName = null, ProductCategory? category = null, bool isActive = false);
       
    }
}
