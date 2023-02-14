#region Imports
using Microsoft.AspNetCore.Mvc;
#endregion

#region Logedin user controller
namespace SQL_WEB_APPLICATION.Controllers
{
    public class LogedInUserController : Controller
    {
        public IActionResult UserIndex()
        {
            return View();
        }

        public IActionResult UserAboutPage()
        {
            return View();
        }

        public IActionResult ProductsPage()
        {
            return View();
        }

        public IActionResult AccountPage()
        {
            return View();
        }

        public IActionResult UserProductsPage()
        {
            return View();
        }
    }
}
#endregion