#region Imports
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.DataObject;
#endregion

#region User repository interface
namespace SQL_WEB_APPLICATION.Context
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserModel>> GetUsers();
        public Task<IEnumerable<UserModel>> GetAllUsers();
        public Task<IEnumerable<UserModel>> CheckUsersId();
        public Task PostUser(UserModel userModel);
        public Task UpdateUser(UserModel userModel);
        public Task DeleteUser(UserDataObject id);
    }
}
#endregion