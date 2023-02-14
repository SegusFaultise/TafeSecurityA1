#region Imports
using Dapper;
using SQL_WEB_APPLICATION.Context;
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
    }
}
#endregion
