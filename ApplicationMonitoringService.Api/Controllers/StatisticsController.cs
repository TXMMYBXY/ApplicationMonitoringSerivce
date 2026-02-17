using ApplicationMonitoringService.Api.Controllers.VIewModels;
using ApplicationMonitoringService.Application.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationMonitoringService.Api.Controllers;

[ApiController]
[Route("api/statistics")]
public class StatisticsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IStatisticService _statisticService;
    
    public StatisticsController(IMapper mapper, IStatisticService statisticService)
    {
        _mapper = mapper;
        _statisticService = statisticService;
    }

    public async Task CreateInfFromDeviceAsync([FromBody] CreateInfoFromDeviceViewModel viewModel)
    {
        
    }
}