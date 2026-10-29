using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class CreateProductService: ICreateProductService
    {
        private readonly IIdObjectFactory<Product> _productFactory;
        private readonly IProductRepository _productRepository;
        private readonly IUpdateProductService _updateProductService;

        public CreateProductService(IIdObjectFactory<Product> productFactory, IProductRepository productRepository, IUpdateProductService updateProductService)
        {
            _productFactory = productFactory;
            _productRepository = productRepository;
            _updateProductService = updateProductService;
        }

        public Product Create(Guid id, string productName, string description, decimal? price, ProductCategory category, int StockQuantity, bool isActive)
        {
            var product = _productFactory.Create(id);
            _updateProductService.Update(product, productName, description, price, category, StockQuantity, isActive);
            _productRepository.Save(product);

            return product;
        }
    }
}
