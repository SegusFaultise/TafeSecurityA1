#region Imports
using Microsoft.AspNetCore.Mvc;
#endregion

#region logedin admin controller
namespace SQL_WEB_APPLICATION.Controllers
{
    public class LogedinAdminController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult AdminAboutPage()
        {
            return View();
        }

        public IActionResult AdminProductsPage()
        {
            return View();
        }

        public IActionResult AdminAccountPage()
        {
            return View();
        }
    }
}
#endregion