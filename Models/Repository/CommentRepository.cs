using Dapper;
using Microsoft.AspNetCore.Mvc;
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models.Dto;
using SQL_WEB_APPLICATION.Models;
using System.Data;

namespace SQL_WEB_APPLICATION.Models.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DapperContext _context;

        public CommentRepository(DapperContext context) =>
            _context = context;

        public async Task PostUserComments(CommentModel commentModel)
        {
            var query = "INSERT INTO [Comments] (comment_text, created_date, fk_user_id, fk_product_id) " +
                        "VALUES (@comment_text, @created_date, @fk_user_id, @fk_product_id) ";

            var parameters = new DynamicParameters();
            parameters.Add("comment_text", commentModel.comment_text, DbType.String);
            parameters.Add("created_date", commentModel.created_date, DbType.String);
            parameters.Add("fk_user_id", commentModel.fk_user_id, DbType.Int32);
            parameters.Add("fk_product_id", commentModel.fk_product_id, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

            //using (var connection = _context.CreateConnection())
            //{
            //    var id = await connection.QuerySingleAsync<int>(query, parameters);

            //    var createdComment = new CommentDto
            //    {
            //        comment_id  = id,
            //        comment_text = commentModel.comment_text,
            //        created_date = commentModel.created_date,
            //        email = commentModel.fk_user_id.ToString(),
            //        product_name = commentModel.fk_product_id.ToString()
            //    };

            //    return createdComment;
            //}
        }

        public async Task<IEnumerable<CommentModel>> GetComments()
        {
            string query = "SELECT Comments.comment_id, Comments.comment_text, Comments.created_date, [User].email, " +
                                     "Products.product_name " +
                                     "FROM [User] INNER JOIN " +
                                     "Comments ON [User].user_id = Comments.fk_user_id " +
                                     "INNER JOIN " +
                                     "Products ON Comments.fk_product_id = Products.product_id ";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<CommentModel>(query);
                return users.ToList();
            }
        }
    }
}
