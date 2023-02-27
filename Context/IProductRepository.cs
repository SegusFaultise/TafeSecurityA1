#region Imports
using SQL_WEB_APPLICATION.Models;
#endregion

#region Product repository interface
namespace SQL_WEB_APPLICATION.Context
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductModel>> GetProducts();
        public Task<IEnumerable<ProductModel>> GetProductName();
        public Task CreateProduct(ProductModel  productModel);
        public Task UpdateProduct(ProductModel productModel);
        public Task DeleteProduct(ProductModel id);
    }
}
#endregion