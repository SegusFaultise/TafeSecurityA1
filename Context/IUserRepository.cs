using SQL_WEB_APPLICATION.Models;

namespace SQL_WEB_APPLICATION.Context
{
    public interface IUserRepository
    {
        //public Task<UserModel> GetUsers();
        public Task<IEnumerable<UserModel>> GetUsers();
        public Task<IEnumerable<UserModel>> PostUsers();
    }
}
