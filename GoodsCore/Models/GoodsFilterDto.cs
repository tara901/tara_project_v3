namespace GoodsCore.Models
{
    public class GoodsFilterDto
    {
        public int? GroupId { get; set; }

        public int? VendorCode { get; set; }

        public int? Price { get; set; }

        public string? NameGoods { get; set; }

        public string? ProductCategory { get; set; }
    }
}
