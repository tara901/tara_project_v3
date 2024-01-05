using AutoMapper;
using Goods.Models;
using GoodsCore.Models;


namespace Goods.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GoodsAddDto, Good>()
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Good, GoodsGetDto>();

            CreateMap<Group, GroupDto>();

            CreateMap<GoodsEditDto, Good>()
                .ForMember(dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.Now));

            //CreateMap<FingerprintBase, FingerprintDto>()
            //    .ForMember(dest => dest.FingerprintId,
            //        opt => opt.MapFrom(src => src.FprtId));
        }
    }
}

