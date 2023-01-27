using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models;

namespace SQL_WEB_APPLICATION.Controllers
{
    [Controller]
    [Route("~/api/[controller]")]

    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(UserModel? userModel)
        {
            string message;
            var loginStatus = _userRepository.GetUsers().Result.Where(m => m.email == userModel.email &&
                                                                              m.password == userModel.password).FirstOrDefault();
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
    }
}
