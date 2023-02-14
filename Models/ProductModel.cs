#region Product model
namespace SQL_WEB_APPLICATION.Models
{
    public class ProductModel
    {
        public int product_id { get; set; }
        public string? product_name { get; set; } = null!;
        public int? product_price { get; set; } = null!;
        public string? product_description { get; set; } = null!;
        public string? updated_date { get; set; } = null!;
    }
}
#endregion