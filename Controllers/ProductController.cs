#region Imports
using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.Repository;
using System.Linq;
#endregion

#region Product controllers
namespace SQL_WEB_APPLICATION.Controllers
{
    [Controller]
    [Route("~/api/[controller]")]
    public class ProductController : Controller
    {
        #region Dapper intialized
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepostory)
        {
            _productRepository = productRepostory;
        }
        #endregion

        #region Gets all of the products
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts(ProductModel? productmodel)
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }
        #endregion

        #region Gets only the product name
        [HttpGet]
        [Route("GetProductName")]
        public async Task<IActionResult> GetProductName(ProductModel? productmodel)
        {
            var products = await _productRepository.GetProductName();
            return Ok(products);
        }
        #endregion

        #region Create new product
        [HttpPost]
        [Route("PostProduct")]
        public async Task<IActionResult> PostProduct(ProductModel productModel)
        {
            await _productRepository.CreateProduct(productModel);
            return Ok("Product created");
        }
        #endregion

        #region Update product
        [HttpPut]
        [Route("PutProduct")]
        public async Task<IActionResult> PutProduct(ProductModel productModel)
        {
            productModel.updated_date = DateTime.Now;
            await _productRepository.UpdateProduct(productModel);
            return Ok("Product updated");
        }
        #endregion

        #region Update product
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(ProductModel id)
        {
            await _productRepository.DeleteProduct(id);
            return Ok("Product deleted");
        }
        #endregion
    }
}
#endregion