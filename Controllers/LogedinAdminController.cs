using Microsoft.AspNetCore.Mvc;

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
