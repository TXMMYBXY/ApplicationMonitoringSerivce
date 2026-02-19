using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonitoringService.Api.Controllers.Statistic.VIewModels;
using MonitoringService.Application.Service;
using MonitoringService.Application.Service.Dto;

namespace MonitoringService.Api.Controllers.Statistic;

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
    
    [HttpPost("add-statistic")]
    public async Task<ActionResult> CreateInfFromDeviceAsync([FromBody] CreateStatisticViewModel statisticViewModel)
    {
        var statisticDto = _mapper.Map<CreateStatisticDto>(statisticViewModel);
        
        await _statisticService.CreateStatisticAsync(statisticDto);
        
        return Created();
    }
}