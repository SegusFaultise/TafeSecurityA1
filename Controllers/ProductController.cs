using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.Repository;

namespace SQL_WEB_APPLICATION.Controllers
{
    [Controller]
    [Route("~/api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepostory)
        {
            _productRepository = productRepostory;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }
    }
}
