#region Imports
using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.DataObject;
using SQL_WEB_APPLICATION.Models.Repository;
using System.Diagnostics.Contracts;
#endregion

#region Comment controller
namespace SQL_WEB_APPLICATION.Controllers
{
    [Controller]
    [Route("~/api/[controller]")]
    public class CommentController : Controller
    {
        #region Dapper intalized
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        #endregion

        #region Gets all comments 
        [HttpGet]
        [Route("GetComments")]
        public async Task<IActionResult> GetComments()
        {
            try
            {
                var comments = await _commentRepository.GetComments();
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Creates new user comment 
        [HttpPost]
        [Route("PostComments")]
        public async Task<IActionResult> PostComments(CommentModel commentModel)
        {
            try
            {
                commentModel.created_date = DateTime.Now;
                await _commentRepository.PostUserComments(commentModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Gets users comments 
        [HttpGet]
        [Route("GetUserComments")]
        public async Task<IActionResult> GetUserComments(CommentModel commentModel)
        {
            try
            {
                var user_comments = await _commentRepository.GetUserComments(commentModel);
                return Ok(user_comments);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Updates users comments 
        [HttpPut]
        [Route("PutUserComment")]
        public async Task<IActionResult> PutUserComment(CommentModel commentModel)
        {
            try
            {
                await _commentRepository.UpdateUserComment(commentModel);
                return Ok("Comment updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        [HttpDelete]
        [Route("DeleteUserComment")]
        public async Task<IActionResult> DeleteUserComment(CommentDataObject commentId)
        {
            try
            {
                await _commentRepository.DeleteUserComment(commentId);
                return Ok("Comment deleted");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
#endregion