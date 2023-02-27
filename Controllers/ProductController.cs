#region Imports
using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.DataObject;
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
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                return Ok(products);
            }
            catch (Exception ex) 
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Gets only the product name
        [HttpGet]
        [Route("GetProductName")]
        public async Task<IActionResult> GetProductName()
        {
            try
            {
                var products = await _productRepository.GetProductName();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Create new product
        [HttpPost]
        [Route("PostProduct")]
        public async Task<IActionResult> PostProduct(ProductModel productModel)
        {
            try
            {
                await _productRepository.CreateProduct(productModel);
                return Ok("Product created");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Update product
        [HttpPut]
        [Route("PutProduct")]
        public async Task<IActionResult> PutProduct(ProductModel productModel)
        {
            try
            {
                productModel.updated_date = DateTime.Now;
                await _productRepository.UpdateProduct(productModel);
                return Ok("Product updated");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Update product
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(ProductDataObject productId)
        {
            try
            {
                await _productRepository.DeleteProduct(productId);
                return Ok("Product deleted");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion
    }
}
#endregion