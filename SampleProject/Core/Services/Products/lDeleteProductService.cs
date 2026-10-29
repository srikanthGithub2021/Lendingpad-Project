using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace Core.Services.Products
{
    public interface IDeleteProductService
    {
        void Delete(Product product);

        void DeleteAll(bool confirm=false);
    }
}
