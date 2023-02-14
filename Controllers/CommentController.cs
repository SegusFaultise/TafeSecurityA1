#region Imports
using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.Dto;
using SQL_WEB_APPLICATION.Models.Repository;
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
            var comments = await _commentRepository.GetComments();
            
            return Ok(comments);
        }
        #endregion

        #region Creates new user comment 
        [HttpPost]
        [Route("PostComments")]
        public async Task<IResult> PostComments([FromBody] CommentModel commentModel)
        {

            await _commentRepository.PostUserComments(commentModel);
            return Results.Ok();
        }
        #endregion
    }
}
#endregion