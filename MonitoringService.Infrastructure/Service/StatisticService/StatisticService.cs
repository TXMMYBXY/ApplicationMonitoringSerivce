using AutoMapper;
using Microsoft.Extensions.Logging;
using MonitoringService.Application.Repository;
using MonitoringService.Application.Service.StatisticService;
using MonitoringService.Application.Service.StatisticService.Dto;
using MonitoringService.Entities;

namespace MonitoringService.Infrastructure.Service.StatisticService;

public class StatisticService : IStatisticService
{
    private readonly ILogger<StatisticService> _logger;
    private readonly IMapper _mapper;
    private readonly IStatisticRepository _statisticRepository;

    public StatisticService(
        ILogger<StatisticService> logger,
        IMapper mapper, 
        IStatisticRepository statisticRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _statisticRepository = statisticRepository;
    }
    
    public async Task CreateStatisticAsync(CreateStatisticDto createStatisticDto)
    {
        _logger.LogInformation($"Starting operation: \"Create new record about device\" \nData:{createStatisticDto}");
        
        var statisticEntity = _mapper.Map<Statistic>(createStatisticDto);
        
        await  _statisticRepository.CreateStatisticAsync(statisticEntity);
        _logger.LogInformation($"Record added about device to database");
        
        await  _statisticRepository.SaveChangesAsync();
        _logger.LogInformation($"Record saved");
    }

    public async Task<IReadOnlyCollection<GetStatisticDto>> GetAllStatisticsAsync()
    {
        var listStatisticsEntity = await _statisticRepository.GetAllStatisticsAsync();
        var listStatisticsDto = _mapper.Map<IReadOnlyCollection<GetStatisticDto>>(listStatisticsEntity);

        return listStatisticsDto;
    }

    public async Task<IReadOnlyCollection<GetStatisticDto>> GetStatisticsByIdAsync(string deviceId)
    {
        var listStatisticsEntity = await _statisticRepository.GetStatisticsByIdAsync(deviceId);
        var listStatisticsDto = _mapper.Map<IReadOnlyCollection<GetStatisticDto>>(listStatisticsEntity);
        
        return listStatisticsDto;
    }

    public async Task<IReadOnlyCollection<GetDeviceDto>> GetAllDevicesAsync()
    {
        var listUniqueDevices = await _statisticRepository.GetAllDevicesAsync();
        var listDevicesDto = _mapper.Map<IReadOnlyCollection<GetDeviceDto>>(listUniqueDevices);

        return listDevicesDto;
    }

    public async Task DeleteStatisticByIdAsync(int statisticId)
    {
        var statisticEntity = await _statisticRepository.GetByIdAsync(statisticId);
        
        if(statisticEntity == null)
            throw new NullReferenceException($"Statistic with id {statisticId} does not exist");
        
        _statisticRepository.Delete(statisticEntity);
        _logger.LogInformation($"Record deleted about device to database");
        
        await  _statisticRepository.SaveChangesAsync();
    }
}