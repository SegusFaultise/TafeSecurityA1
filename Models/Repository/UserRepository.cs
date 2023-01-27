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
            var query = "SELECT * FROM [User]";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<UserModel>(query);
                return users.ToList();
            }
        }

        //public async Task<UserModel> GetUsers()
        //{
        //    var procedureName = "spUser_GetAll";
        //    //var param = new DynamicParameters();
        //    //param.Add("name", procedureName);

        //    using (var connection = _context.CreateConnection())
        //    {
        //        var user = await connection.QueryFirstOrDefault<UserModel>(procedureName, commandType: CommandType.StoredProcedure);
        //    }
        //}
    }
}
