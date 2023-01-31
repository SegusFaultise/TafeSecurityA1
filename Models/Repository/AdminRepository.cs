using Dapper;
using SQL_WEB_APPLICATION.Context;
using System.Data;

namespace SQL_WEB_APPLICATION.Models.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DapperContext _context;

        public AdminRepository(DapperContext context) =>
            _context = context;

        public async Task<IEnumerable<AdminModel>> GetAdmin()
        {
            var query = "SELECT email, password FROM [Admin]";

            using (var connection = _context.CreateConnection())
            {
                var admin = await connection.QueryAsync<AdminModel>(query);
                return admin.ToList();
            }
        }

        public async Task<IEnumerable<AdminModel>> CheckAdmin()
        {
            var query = "SELECT admin_id, email, password FROM [Admin]";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<AdminModel>(query.Trim());
                return users.ToList();
            }
        }

        public async Task PostAdmin(AdminModel adminModel)
        {
            var query = "INSERT INTO [Admin] (email, password) " +
                        "VALUES (@email, @password) ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query.Trim(), adminModel);
            }
        }
    }
}
