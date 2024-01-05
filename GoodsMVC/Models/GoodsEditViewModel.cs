using Goods.Models;
using GoodsCore.Models;

namespace GoodsMVC.Models
{
    public class GoodsEditViewModel
    {
        public GoodsGetDto? Goods { get; set; }

        public List<GroupDto>? Groups { get; set; }
    }
}
