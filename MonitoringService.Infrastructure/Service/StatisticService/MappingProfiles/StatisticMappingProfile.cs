using System.Xml.Serialization;
using AutoMapper;
using MonitoringService.Application.Service.StatisticService.Dto;
using MonitoringService.Entities;

namespace MonitoringService.Application.Service.StatisticService.MappingProfiles;

public class StatisticMappingProfile : Profile
{
    public StatisticMappingProfile()
    {
        //Profiles for POST
        CreateMap<CreateStatisticDto, Statistic>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
        
        //Profiles for GET
        CreateMap<Statistic, GetStatisticDto>().ReverseMap();

        CreateMap<string, GetDeviceDto>().ForMember(dest => dest.DeviceId, opt => opt.MapFrom(src => src));
    }
}