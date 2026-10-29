using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class DeleteProductService:IDeleteProductService
    {

        private readonly IProductRepository _productRepository;
        public DeleteProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }
        public void DeleteAll(bool confirm=false)
        {
            if(!confirm)
            {
                throw new InvalidOperationException("DeleteAll requires Explicit confirmation. pass confirm: true to proceed. ");
            }
            _productRepository.DeleteAll();
        }
    }
}
