#region Imports
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.DataObject;
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
        public Task DeleteProduct(ProductDataObject product_id);
    }
}
#endregion