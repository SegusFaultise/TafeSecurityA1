#region Imports
using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Services;
using System.Diagnostics;
#endregion

#region Logedin user controller
namespace SQL_WEB_APPLICATION.Controllers
{
    public class LogedInUserController : Controller
    {
        private readonly ILogger<LogedInUserController> _logger;
        private readonly FileUploaderService _uploader;

        public LogedInUserController(ILogger<LogedInUserController> logger, FileUploaderService uploader)
        {
            _logger = logger;
            _uploader = uploader;
        }

        [HttpPost]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            await _uploader.SaveFile(file);
            return View("AccountPage");
        }

        [HttpPost]
        public async Task<ActionResult> DownloadFile(string fileName)
        {
            byte[]? fileBytes = await _uploader.LoadEncryptedFile(fileName);

            if (fileBytes == null || fileBytes.Length == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return File(fileBytes, "application/octet-stream", fileDownloadName: fileName);
        }

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
#endregion