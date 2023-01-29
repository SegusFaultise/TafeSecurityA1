using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.Dto;

namespace SQL_WEB_APPLICATION.Controllers
{
    [Controller]
    [Route("~/api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpPost]
        [Route("postComments")]
        public async Task<IActionResult> GetProducts([FromBody] Models.Dto.CommentModel commentModel)
        {
            await _commentRepository.PostUserComments(commentModel);
            return NoContent();
        }
    }
}
