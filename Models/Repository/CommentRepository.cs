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

        public async Task<CommentDto> PostUserComments(CommentModel commentModel)
        {
            var query = "INSERT INTO [Comments] (comment_text, created_date, fk_user_id, fk_product_id) " +
                        "VALUES (@comment_text, @created_date, @fk_user_id, @fk_product_id)";

            var parameters = new DynamicParameters();
            parameters.Add("comment_text", commentModel.comment_text, DbType.String);
            parameters.Add("created_date", commentModel.created_date, DbType.String);
            parameters.Add("fk_user_name", commentModel.fk_user_id, DbType.String);
            parameters.Add("fk_product_id", commentModel.fk_product_id, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

                var createdComment = new CommentDto
                {

                    comment_text = commentModel.comment_text,
                    created_date = commentModel.created_date,
                     = commentModel.fk_user_id.ToString(),
                    product_name = commentModel.fk_product_id.ToString()
                };

                return createdComment;
            }
        }

        public Task PostUserComments(CommentDto commentDto)
        {
            throw new NotImplementedException();
        }
    }
}
