using Dapper;
using SQL_WEB_APPLICATION.Context;

namespace SQL_WEB_APPLICATION.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
            private readonly DapperContext _context;

            public ProductRepository(DapperContext context) =>
                _context = context;

            public async Task<IEnumerable<ProductModel>> GetProducts()
            {
                var query = "SELECT * FROM [Products]";

                using (var connection = _context.CreateConnection())
                {
                    var users = await connection.QueryAsync<ProductModel>(query);
                    return users.ToList();
                }
            }

            public async Task<IEnumerable<ProductModel>> GetProductName()
            {
                var query = "SELECT product_name FROM [Products]";

                using (var connection = _context.CreateConnection())
                {
                    var users = await connection.QueryAsync<ProductModel>(query);
                    return users.ToList();
                }
            }
        }
    }

