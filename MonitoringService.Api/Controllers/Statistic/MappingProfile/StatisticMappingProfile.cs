using AutoMapper;
using MonitoringService.Api.Controllers.Statistic.VIewModels;
using MonitoringService.Application.Service.Dto;

namespace MonitoringService.Api.Controllers.Statistic.MappingProfile;

public class StatisticMappingProfile : Profile
{
    public StatisticMappingProfile()
    {
        CreateMap<CreateStatisticViewModel, CreateStatisticDto>().ReverseMap();
    }
}