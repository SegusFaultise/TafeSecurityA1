#region Imports
using Dapper;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models.Dto;
using System.Data;
#endregion

#region User Repository
namespace SQL_WEB_APPLICATION.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Dapper instalized 
        private readonly DapperContext _context;

        public UserRepository(DapperContext context) => 
            _context = context;
        #endregion

        #region Get users for authentication 
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var query = "SELECT email, password FROM [User]";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<UserModel>(query);
                return users.ToList();
            }
        }
        #endregion

        #region Get all users for admin view
        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var query = "SELECT * FROM [User]";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<UserModel>(query);
                return users.ToList();
            }
        }
        #endregion

        #region Gets user_id and updates details
        public async Task<IEnumerable<UserModel>> CheckUsersId()
        {
            var query = "SELECT user_id FROM [User]";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<UserModel>(query);

                return users.ToList();
            }
        }
        #endregion

        #region Creates new user account
        public async Task PostUser(UserModel userModel)
        {
            var query = "INSERT INTO [User] (email, password) " +
                        "VALUES (@email, @password) ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query.Trim(), userModel);
            }
        }
        #endregion

        #region Updates user account details
        public async Task UpdateUser(UserModel userModel)
        {
            var query = "UPDATE [User] " +
                        "SET email = @email," +
                        "password = @password " +
                        "WHERE user_id = @user_id ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, userModel);
            }
        }
        #endregion

        #region Delete user account
        public async Task DeleteUser(UserModel id)
        {
            var query = "DELETE [User] " +
                        "WHERE user_id = @user_id ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, id);
            }
        }
        #endregion
    }
}
#endregion