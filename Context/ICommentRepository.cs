#region Imports
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.Dto;
#endregion

#region Comment repository interface 
namespace SQL_WEB_APPLICATION.Context
{
    public interface ICommentRepository
    {
        public Task PostUserComments(CommentModel commentModel);
        public Task<IEnumerable<CommentModel>> GetComments();
    }
}
#endregion