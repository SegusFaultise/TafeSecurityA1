namespace SQL_WEB_APPLICATION.Models
{
    public class UserModel
    {
        public int user_id { get; set; }
        public string? email { get; set; } = null!;
        public string? password { get; set; } = null!;
    }
}
