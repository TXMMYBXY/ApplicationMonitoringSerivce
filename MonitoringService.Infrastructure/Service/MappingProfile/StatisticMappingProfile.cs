using AutoMapper;
using MonitoringService.Application.Service.Dto;
using MonitoringService.Entities;

namespace MonitoringService.Infrastructure.Service.MappingProfile;

public class StatisticMappingProfile : Profile
{
    public StatisticMappingProfile()
    {
        CreateMap<CreateStatisticDto, Statistic>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
    }
}