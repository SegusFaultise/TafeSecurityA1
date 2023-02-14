#region Admin model
namespace SQL_WEB_APPLICATION.Models
{
    public class AdminModel
    {
        public int admin_id { get; set; }
        public string? email { get; set; } = null!;
        public string? password { get; set; } = null!;
    }
}
#endregion