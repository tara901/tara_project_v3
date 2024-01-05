using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Goods.Models
{
    public class Good
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public Group? Group { get; set; }

        public string NameGoods { get; set; }

        public string ProductCategory { get; set; }

        public int VendorCode { get; set; }

        public int Price { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
