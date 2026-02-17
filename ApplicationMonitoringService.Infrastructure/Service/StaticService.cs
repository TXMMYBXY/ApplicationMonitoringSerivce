using ApplicationMonitoringService.Application.Repository;
using ApplicationMonitoringService.Application.Service;
using ApplicationMonitoringService.Application.Service.Dto;
using ApplicationMonitoringService.Entities;
using AutoMapper;

namespace ApplicationMonitoringService.Infrastructure.Service;

public class StaticService : IStatisticService
{
    private readonly IMapper _mapper;
    private readonly IStatisticRepository _repository;

    public StaticService(IMapper mapper, IStatisticRepository statistic)
    {
        _mapper = mapper;
        _repository = statistic;
    }
    
    public async Task CreateStatisticAsync(CreateStatisticDto createStatisticDto)
    {
        var statisticEntity = _mapper.Map<Statistic>(createStatisticDto);
        
        await  _repository.CreateStatisticAsync(statisticEntity);
    }
}