using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository : InMemoryRepository<Product>, IProductRepository
    {
        public ProductRepository(IInMemoryStorage<Product> storage) : base(storage)
        {

        }
        public IEnumerable<Product> Get(string ProductName = null, ProductCategory? category = null, bool? isactive = null)
        {
            var query = Storage.GetAll();
            if (!string.IsNullOrEmpty(ProductName))
            {
                query = query.Where(p => p.ProductName == ProductName);
            }

            if (category != null)
            {
                query = query.Where(p => p.category == category);
            }

            if (isactive != null)
            {
                query = query.Where(p => p.IsActive == isactive);
            }
            return query.ToList();
        }
        public void DeleteAll()
        {
            foreach(var product in Storage.GetAll().ToList())
            {
                Storage.Delete(product);
            }
        }
    }

}
