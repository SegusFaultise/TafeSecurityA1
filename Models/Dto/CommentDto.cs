namespace SQL_WEB_APPLICATION.Models.Dto
{
    public class CommentDto
    {
        public int comment_id { get; set; }
        public string email { get; set; } = null!;
        public string product_name { get; set; } = null!;
        public string comment_text { get; set; } = null!;
        public string created_date { get; set; } = null!;
    }
}
