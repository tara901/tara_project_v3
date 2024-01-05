using Goods.Models;
using GoodsCore.Models;

namespace GoodsMVC.Models
{
    public class GoodsViewModel
    {
        public List<GoodsGetDto> Goods { get; set; }

        public List<GroupDto> Groups { get; set; }

        public GoodsFilterDto Filter { get; set; }
    }
}
