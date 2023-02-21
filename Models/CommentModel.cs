#region Comment model
namespace SQL_WEB_APPLICATION.Models
{
    public class CommentModel
    {
        public int comment_id { get; set; }
        public int fk_product_id { get; set; }
        public string email { get; set; } = null!;
        public string comment_text { get; set; } = null!;
        public DateTime created_date { get; set; }
        public string session_id { get; set; } = null!;
    }
}
#endregion