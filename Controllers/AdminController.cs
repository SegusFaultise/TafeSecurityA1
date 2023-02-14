#region Imports
using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models;
#endregion

#region Admin controller
namespace SQL_WEB_APPLICATION.Controllers
{
    [Controller]
    [Route("~/api/[controller]")]
    public class AdminController : Controller
    {
        #region Dapper intialized
        private readonly IAdminRepository _adminResository;

        public AdminController(IAdminRepository adminRepository)
        {
             _adminResository = adminRepository;
        }
        #endregion

        #region Authenticates the admin login
        [HttpGet]
        [Route("AuthenticateLogin")]
        public async Task<IActionResult> AuthenticateLogin(AdminModel? adminModel)
        {
            string message;
            var loginStatus = _adminResository.GetAdmin().Result.Where(m => m.email.Trim() == adminModel.email &&
                                                                                          m.password.Trim() == adminModel.password).FirstOrDefault();
            if (loginStatus != null)
            {
                message = "LOGIN VALID";
            }
            else
            {
                message = "LOGIN INVALID";
            }
            return Json(message);
        }
        #endregion

        #region Checks if the inputed details and if it matches an admin account will be created
        [HttpGet]
        [Route("CheckAdmin")]
        public async Task<IActionResult> CheckAdmin(AdminModel? adminModel)
        {
            string message;
            var checkStatus = _adminResository.CheckAdmin().Result.Where(m => m.email.Trim() == adminModel.email).FirstOrDefault();
            if (checkStatus == null)
            {
                message = "LOGIN VALID";
                await _adminResository.PostAdmin(adminModel);
            }
            else
            {
                message = "LOGIN INVALID";
            }
            return Json(message);
        }
        #endregion
    }
}
#endregion