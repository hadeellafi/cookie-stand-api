using AutoMapper;
using CookieStandApi.Models.Entities;
using CookieStandAPI.Models.DTOs;

namespace CookieStandAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CookieStand, CookieStandDto>()
                .ForMember(dest => dest.HourlySales, opt => opt.MapFrom(src => src.HourlySales.Select(hs => new HourlySaleView { Sales = hs.Sales })))
                .ReverseMap();

            CreateMap<HourlySale, HourlySaleDto>()
                .ReverseMap();
        }
    }

}
