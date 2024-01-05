using Goods.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodsCore.Models
{
    public class GoodsGetDto
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public GroupDto? Group { get; set; }

        public int VendorCode { get; set; }

        public int Price { get; set; }

        public string NameGoods { get; set; }

        public string ProductCategory { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

