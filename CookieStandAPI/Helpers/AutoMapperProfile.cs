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
                .ForMember(dest => dest.HourlySales, opt => opt.MapFrom(src => src.HourlySales.Select(hs => hs.HourSale)))
                .ReverseMap();
            CreateMap<HourlySaleDto, HourlySale>().ReverseMap();

        }

    }

}
