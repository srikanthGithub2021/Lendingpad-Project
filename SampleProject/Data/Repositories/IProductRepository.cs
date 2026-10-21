using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public  interface IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> Get(string ProductName = null, ProductCategory? category = null, bool? isactive  = null);
        void DeleteAll();
    }
}
