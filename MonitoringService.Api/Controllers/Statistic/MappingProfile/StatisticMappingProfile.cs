using AutoMapper;
using MonitoringService.Api.Controllers.Statistic.VIewModels;
using MonitoringService.Application.Service.StatisticService.Dto;

namespace MonitoringService.Api.Controllers.Statistic.MappingProfile;

public class StatisticMappingProfile : Profile
{
    public StatisticMappingProfile()
    {
        //Profiles for POST
        CreateMap<CreateStatisticViewModel, CreateStatisticDto>().ReverseMap();
        
        //Profiles for GET
        CreateMap<GetStatisticDto, GetStatisticViewModel>().ReverseMap();
        
        CreateMap<GetDeviceDto, GetDeviceViewModel>().ReverseMap();
    }
}