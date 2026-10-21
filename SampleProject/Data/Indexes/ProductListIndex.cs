using BusinessEntities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Indexes
{
  
    public class ProductListIndex : AbstractIndexCreationTask<Product>
    {
        public ProductListIndex()
        {
            Map = products => from product in products
                           select new
                           {

                               product.ProductName,
                               product.Description,
                               product.category
                              
                           };

            Index(x => x.category, FieldIndexing.NotAnalyzed);
        }
    }
}
