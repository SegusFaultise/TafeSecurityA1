#region Imports
using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.Dto;
using SQL_WEB_APPLICATION.Models.Repository;
using System.Text.RegularExpressions;
#endregion

#region User controller
namespace SQL_WEB_APPLICATION.Controllers
{
    [Controller]
    [Route("~/api/[controller]")]

    public class UserController : Controller
    {
        #region Dapper intailized
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Email validation using regex
        static bool EmailValidation(string email)
        {
            Regex emailValidation = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return emailValidation.IsMatch(email);
        }
        #endregion

        #region Authenticates user login
        [HttpGet]
        [Route("AuthenticateLogin")]
        public async Task<IActionResult> AuthenticateLogin(UserModel? userModel)
        {
            string message;
            var loginStatus = _userRepository.GetUsers().Result.Where(m => m.email.Trim() == userModel.email &&
                                                                                          m.password.Trim() == userModel.password).FirstOrDefault();
            var email_valadtion = EmailValidation(userModel.email);

            if (loginStatus != null & email_valadtion == true)
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

        #region Checks user login
        [HttpGet]
        [Route("CheckLogin")]
        public async Task<IActionResult> CheckLogin(UserModel? userModel)
        {
            string message;
            var checkStatus = _userRepository.CheckUsers().Result.Where(m => m.email.Trim() == userModel.email &&
                                                                                          m.password.Trim() == userModel.password).FirstOrDefault();
            if (checkStatus != null)
            {
                message = "LOGIN VALID";
                return Ok(checkStatus.user_id);
            }
            else
            {
                message = "LOGIN INVALID";
            }
            return Json(message);
        }
        #endregion

        #region Gets all of the users
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }
        #endregion

        #region Checks if the inputed detials match an entry in the [User] table if so the creates a new user
        [HttpGet]
        [Route("CheckUser")]
        public async Task<IActionResult> CheckUser(UserModel? userModel)
        {
            string message;
            var checkStatus = _userRepository.CheckUsers().Result.Where(m => m.email.Trim() == userModel.email).FirstOrDefault();
            if (checkStatus == null)
            {
                message = "LOGIN VALID";
                await _userRepository.PostUser(userModel);
            }
            else
            {
                message = "LOGIN INVALID";
            }
            return Json(message);
        }
        #endregion

        #region Checks if the inputed detials match an entry in the [User] table if so the creates a new user
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserModel userModel)
        {
            string message;
            var email = userModel.email;
            var email_valadation = EmailValidation(email);

            if (email_valadation == true)
            {
                message = "UPDATE COMPLETE";
                await _userRepository.UpdateUser(userModel);
            }
            else
            {
                message = "UPDATE ERROR";
            }
            return Json(message);
        }
        #endregion
    }
}
#endregion