using AutoMapper;
using MonitoringService.Application.Repository;
using MonitoringService.Application.Service;
using MonitoringService.Application.Service.Dto;
using MonitoringService.Entities;

namespace MonitoringService.Infrastructure.Service;

public class StatisticService : IStatisticService
{
    private readonly IMapper _mapper;
    private readonly IStatisticRepository _repository;

    public StatisticService(IMapper mapper, IStatisticRepository statistic)
    {
        _mapper = mapper;
        _repository = statistic;
    }
    
    public async Task CreateStatisticAsync(CreateStatisticDto createStatisticDto)
    {
        var statisticEntity = _mapper.Map<Statistic>(createStatisticDto);
        
        await  _repository.CreateStatisticAsync(statisticEntity);
        await  _repository.SaveChangesAsync();
    }
}