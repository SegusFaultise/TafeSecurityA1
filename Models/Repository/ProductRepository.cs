#region Imports
using Dapper;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models.DataObject;
#endregion

#region Product repository
namespace SQL_WEB_APPLICATION.Models.Repository
{
    public class ProductRepository : IProductRepository
    {

        #region Dapper inastilzed
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context) =>
            _context = context;
        #endregion

        #region Gets all products for product view
        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            var query = "SELECT * FROM [Products]";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<ProductModel>(query);
                return users.ToList();
            }
        }
        #endregion

        #region Selects only the gpu field for a combo box 
        public async Task<IEnumerable<ProductModel>> GetProductName()
        {
            var query = "SELECT product_name FROM [Products]";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<ProductModel>(query);
                return users.ToList();
            }
        }
        #endregion

        #region Creates a product
        public async Task CreateProduct(ProductModel productModel)
        {
            var query = "INSERT INTO [Products] (product_price, product_description, product_name) " +
                        "VALUES (@product_price, @product_description, @product_name) ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query.Trim(), productModel);
            }
        }
        #endregion

        #region Updates product details
        public async Task UpdateProduct(ProductModel productModel)
        {
            var query = "UPDATE [Products] " +
                        "SET product_price = @product_price, " +
                        "product_description = @product_description, " +
                        "product_name = @product_name, " +
                        "updated_date = @updated_date " +
                        "WHERE product_id = @product_id ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, productModel);
            }
        }
        #endregion

        #region Delete product
        public async Task DeleteProduct(ProductDataObject product_id)
        {
            var query = "DELETE [Products] " +
                        "WHERE product_id = @product_id ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, product_id);
            }
        }
        #endregion`
    }
}
#endregion
