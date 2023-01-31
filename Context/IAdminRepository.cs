using SQL_WEB_APPLICATION.Models;

namespace SQL_WEB_APPLICATION.Context
{
    public interface IAdminRepository
    {
        public Task<IEnumerable<AdminModel>> GetAdmin();
        public Task PostAdmin(AdminModel adminModel);
    }
}
