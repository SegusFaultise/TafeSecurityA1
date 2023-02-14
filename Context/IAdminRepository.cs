#region Imports
using SQL_WEB_APPLICATION.Models;
#endregion

#region Admin repository interface
namespace SQL_WEB_APPLICATION.Context
{
    public interface IAdminRepository
    {
        public Task<IEnumerable<AdminModel>> GetAdmin();
        public Task<IEnumerable<AdminModel>> CheckAdmin();
        public Task PostAdmin(AdminModel adminModel);
    }
}
#endregion