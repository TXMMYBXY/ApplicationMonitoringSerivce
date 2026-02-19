using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonitoringService.Api.Controllers.Statistic.VIewModels;
using MonitoringService.Application.Service.StatisticService;
using MonitoringService.Application.Service.StatisticService.Dto;

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

    [HttpGet("get-all-statistics")]
    public async Task<ActionResult<IReadOnlyCollection<GetStatisticViewModel>>> GetAllStatistics()
    {
        var listStatisticsDto = await _statisticService.GetAllStatisticsAsync();
        var listStatisticViewModel = _mapper.Map<IReadOnlyCollection<GetStatisticViewModel>>(listStatisticsDto);
        
        return Ok(listStatisticViewModel);
    }

    [HttpGet("{deviceId}/get-all-statistics-by-device")]
    public async Task<ActionResult<IReadOnlyCollection<GetStatisticViewModel>>> GetAllStatisticsByDevice([FromRoute]string deviceId)
    {
        var listStatisticsDto = await _statisticService.GetStatisticsByIdAsync(deviceId);
        var listStatisticsViewModel = _mapper.Map<IReadOnlyCollection<GetStatisticViewModel>>(listStatisticsDto);
        
        return Ok(listStatisticsViewModel);
    }
    
    [HttpGet("get-all-devices")]
    public async Task<ActionResult<IReadOnlyCollection<GetDeviceViewModel>>> GetAllDevices()
    {
        var listDevicesDto = await _statisticService.GetAllDevicesAsync();
        var listDevicesViewModel = _mapper.Map<IReadOnlyCollection<GetDeviceViewModel>>(listDevicesDto);
        
        return Ok(listDevicesViewModel);
    }

    [HttpDelete("delete-statistic")]
    public async Task DeleteStatisticByIdAsync([FromBody] DeleteStatisticViewModel  statisticViewModel)
    {
        var statisticId =  statisticViewModel.Id;
        await _statisticService.DeleteStatisticByIdAsync(statisticId);
    }
}