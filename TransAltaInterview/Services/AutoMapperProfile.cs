using AutoMapper;
using TransAltaInterview.Models;

namespace TransAltaInterview.Services
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<WeatherNetworkReport, WeatherRecord>()
                .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => src.obs.updatetime_stamp_gmt))
                .ForMember(dest => dest.WindSpeed, opt => opt.MapFrom(src => src.obs.w))
                .ForMember(dest => dest.WindSpeedGust, opt => opt.MapFrom(src => src.obs.wg))
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.obs.t))
                .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.obs.h));
        }
    }
}
