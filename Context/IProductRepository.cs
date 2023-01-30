using SQL_WEB_APPLICATION.Models;

namespace SQL_WEB_APPLICATION.Context
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductModel>> GetProducts();
        public Task<IEnumerable<ProductModel>> GetProductName();
    }
}
