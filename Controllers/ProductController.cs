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
    }
}
#endregion