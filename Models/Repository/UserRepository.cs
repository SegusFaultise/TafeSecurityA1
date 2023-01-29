using Dapper;
using SQL_WEB_APPLICATION.Context;
using System.Data;

namespace SQL_WEB_APPLICATION.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context) => 
            _context = context;

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var query = "SELECT email, password FROM [User]";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<UserModel>(query);
                return users.ToList();
            }
        }

        public async Task<IEnumerable<UserModel>> CheckUsers()
        {
            var query = "SELECT user_id, email, password FROM [User]";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<UserModel>(query);
                return users.ToList();
            }
        }

        //public async Task<IEnumerable<UserModel>> CheckLoginInfo()
        //{
        //    var query = "DECLARE @password NCHAR " +
        //                "SELECT user_id, email, password " +
        //                "FROM dbo.[User] " +
        //                "WHERE password = @password; ";

        //    using (var connection = _context.CreateConnection())
        //    {
        //        var users = await connection.QueryAsync<UserModel>(query);
        //        return users.ToList();
        //    }
        //}
    }
}
