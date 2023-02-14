#region Imports
using Dapper;
using SQL_WEB_APPLICATION.Context;
using System.Data;
#endregion

#region Admin repository
namespace SQL_WEB_APPLICATION.Models.Repository
{
    public class AdminRepository : IAdminRepository
    {
        #region Dapper initalized
        private readonly DapperContext _context;

        public AdminRepository(DapperContext context) =>
            _context = context;
        #endregion

        #region Checks if the inputed login is equal to a existing admin login 
        public async Task<IEnumerable<AdminModel>> GetAdmin()
        {
            var query = "SELECT email, password FROM [Admin]";

            using (var connection = _context.CreateConnection())
            {
                var admin = await connection.QueryAsync<AdminModel>(query.Trim());
                return admin.ToList();
            }
        }
        #endregion

        #region Gets the admin_id from the loged in user
        public async Task<IEnumerable<AdminModel>> CheckAdmin()
        {
            var query = "SELECT admin_id, email, password FROM [Admin]";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<AdminModel>(query.Trim());
                return users.ToList();
            }
        }
        #endregion

        #region Creates a new admin account 
        public async Task PostAdmin(AdminModel adminModel)
        {
            var query = "INSERT INTO [Admin] (email, password) " +
                        "VALUES (@email, @password) ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query.Trim(), adminModel);
            }
        }
        #endregion
    }
}
#endregion