using BusinessEntities;
using Core.Services.Products;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController: BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IUpdateProductService _updateProductService;
        private readonly IGetProductService _getProductService;
        private readonly IDeleteProductService _deleteProductService;


        public ProductController(ICreateProductService createProductService, IUpdateProductService updateProductService, IGetProductService getProductService, IDeleteProductService deleteProductService)
        {
            _createProductService = createProductService;
            _updateProductService = updateProductService;
            _getProductService = getProductService;
            _deleteProductService = deleteProductService;
        }
        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {
            var product = _getProductService.GetProduct(productId);
            if (product != null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Product already exist for productId: {productId}");
               
            }
           
            product= _createProductService.Create(productId, model.ProductName, model.Description, model.Price, model.Category, model.StockQuantity, model.IsActive);
            return Found(new ProductData(product));

        }


        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {

            var product = _getProductService.GetProduct(productId);
            if(product == null) {
                return DoesNotExist();
            }
            _updateProductService.Update(product, model.ProductName, model.Description, model.Price, model.Category, model.StockQuantity, model.IsActive);
            return Found(new ProductData(product));

        }

        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid productId)
        {

            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"No Product found for productId: {productId}");
            }
            
            return Found(new ProductData(product));

        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts(int skip, int take, string productName = null, ProductCategory? category = null, bool? isActive = null)
        {

            var products = _getProductService.GetProducts(productName, category, isActive)
                                             .Skip(skip).Take(take)
                                             .Select(p => new ProductData(p))
                                             .ToList();
            //if (products == null ||products.Count==0)
            //{

            //    return Request.CreateResponse(HttpStatusCode.OK, products);
            //}

            return Found(products);

        }

        [Route("Clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllProducts()
        {
            _deleteProductService.DeleteAll(confirm:true);
            return Found();

        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeletePrduct(Guid productId)
        {
            var product=_getProductService.GetProduct(productId);

            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"No Product found for productId: {productId}");
            }

            _deleteProductService.Delete(product);
            return Found();

        }

    }
}