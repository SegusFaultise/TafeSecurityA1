#region Imports
using SQL_WEB_APPLICATION.Models;
using SQL_WEB_APPLICATION.Models.DataObject;
#endregion

#region Comment repository interface 
namespace SQL_WEB_APPLICATION.Context
{
    public interface ICommentRepository
    {
        public Task PostUserComments(CommentModel commentModel);
        public Task UpdateUserComment(CommentModel commentModel);
        public Task DeleteUserComment(CommentDataObject comment_id);
        public Task<IEnumerable<CommentModel>> GetComments();
        public Task<IEnumerable<CommentModel>> GetUserComments(CommentModel commentModel);
    }
}
#endregion