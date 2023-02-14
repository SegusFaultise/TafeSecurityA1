#region Imports
using Dapper;
using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models.Dto;
using SQL_WEB_APPLICATION.Models;
using System.Data;
#endregion

#region Comment repository
namespace SQL_WEB_APPLICATION.Models.Repository
{
    public class CommentRepository : ICommentRepository
    {
        #region Dapper instalized
        private readonly DapperContext _context;

        public CommentRepository(DapperContext context) =>
            _context = context;
        #endregion

        #region Creates a new user comment with a forigen key from the [Product] table
        public async Task PostUserComments(CommentModel commentModel)
        {
            ProductModel productModel = new ProductModel();
            UserModel userModel = new UserModel();
            CommentDto commentDto = new CommentDto();

            var query = "INSERT INTO [Comments] (comment_text, created_date, email, fk_product_id) " +
                        "VALUES (@comment_text, @created_date, @email, @fk_product_id) ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, commentModel);
            }
        }
        #endregion

        #region Gets all of the comments and displays them in a view
        public async Task<IEnumerable<CommentModel>> GetComments()
        {
            string query = "SELECT Comments.comment_id, Comments.comment_text, Comments.created_date, " +
                                     "Products.product_name " +
                                     "FROM Products  INNER JOIN " +
                                     "Comments ON Products.product_id = Comments.fk_product_id ";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<CommentModel>(query);
                return users.ToList();
            }
        }
        #endregion
    }
}
#endregion