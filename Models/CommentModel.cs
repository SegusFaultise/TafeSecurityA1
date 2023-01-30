namespace SQL_WEB_APPLICATION.Models
{
    public class CommentModel
    {
        public int comment_id { get; set; }
        public int fk_user_id { get; set; }
        public int fk_product_id { get; set; }
        public string comment_text { get; set; } = null!;
        public string created_date { get; set; } = null!;
    }
}
