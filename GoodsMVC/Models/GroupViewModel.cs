using GoodsCore.Models;
using Goods.Models;

namespace GoodsMVC.Models
{
    public class GroupViewModel
    {
        public List<GroupDto> Groups { get; set; }

        public GroupFilterDto Filter { get; set; }
    }
}
