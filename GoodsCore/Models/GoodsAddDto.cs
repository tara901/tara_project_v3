using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsCore.Models
{
    public class GoodsAddDto
    {
        public int GroupId { get; set; }

        public int VendorCode { get; set; }

        public int Price { get; set; }

        public string NameGoods { get; set; }

        public string ProductCategory { get; set; }

        public string Password { get; set; }
    }
}
