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

        public UserController(IUserRepository user_repository)
        {
            _userRepository = user_repository;
        }
        #endregion

        #region Email validation using regex
        static bool EmailValidation(string email)
        {
            Regex email_validation = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return email_validation.IsMatch(email);
        }
        #endregion

        #region Get user id
        [HttpGet]
        [Route("GetSessionId")]
        public async Task<IActionResult> GetSessionId()
        {
            string id = HttpContext.Session.Id;

            try
            {
                return Ok(id);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Authenticates user login
        [HttpGet]
        [Route("AuthenticateLogin")]
        
        public async Task<IActionResult> AuthenticateLogin(UserModel? user_model)
        {
            string message;
            var login_status = _userRepository.GetUsers().Result.Where(m => m.email.Trim() 
                                                                      == user_model.email &&                    
                                                                      m.password.Trim() 
                                                                      == user_model.password).FirstOrDefault();
            var email_valadtion = EmailValidation(user_model.email);

            try
            {
                if(login_status != null)
                {
                    string id = HttpContext.Session.Id;
                    HttpContext.Session.GetString(id);
                    message = "LOGIN VALID";
                }

                else
                {
                    message = "LOGIN INVALID";
                }

                return Json(message);
            }
            catch (Exception ex) 
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Checks user login
        [HttpGet]
        [Route("CheckLogin")]
        public async Task<IActionResult> CheckLogin(UserModel? user_model)
        {
            string message;
            var check_status = _userRepository.GetAllUsers().Result.Where(m => m.email.Trim() 
                                                                        == user_model.email &&
                                                                        m.password.Trim() 
                                                                        == user_model.password).FirstOrDefault();
            try
            {
                if (check_status != null)
                {
                    message = "LOGIN VALID";
                    return Ok(check_status.user_id);
                }

                else
                {
                    message = "LOGIN INVALID";
                }

                return Json(message);
            }
            catch (Exception ex) 
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Gets all of the users
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            try
            {
                return Ok(users);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Checks if the inputed detials match an entry in the [User] table if so the creates a new user
        [HttpGet]
        [Route("CheckUser")]
        public async Task<IActionResult> CheckUser(UserModel? user_model)
        {
            string message;
            var check_status = _userRepository.GetUsers().Result.Where(m => m.email.Trim() 
                                                                         == user_model.email).FirstOrDefault();
            var email_valadtion = EmailValidation(user_model.email);

            try
            {
                if (check_status != null)
                {
                    message = "LOGIN INVALID";
                }

                else if (email_valadtion == false)
                {
                    message = "ENTER A EMAIL";
                }

                else
                {
                    message = "LOGIN VALID";
                    await _userRepository.PostUser(user_model);
                }
                
                return Json(message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Checks if the inputed detials match an entry in the [User] table if so the updates a users details
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserModel user_model)
        {
            string message;
            var email = user_model.email;
            var email_valadation = EmailValidation(email);

            try
            {
                if (email_valadation == false)
                {
                    message = "UPDATE ERROR";
                }

                else
                {
                    message = "UPDATE COMPLETE";
                    await _userRepository.UpdateUser(user_model);
                }

                return Json(message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Checks if the inputed detials match an entry in the [User] table if so the deletes user
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(UserModel id)
        {
            try
            {
                await _userRepository.DeleteUser(id);
                return Json("ACCOUNT DELETED");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion
    }
}
#endregion