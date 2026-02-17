using ApplicationMonitoringService.Application.Service.Dto;

namespace ApplicationMonitoringService.Application.Service;

public interface IStatisticService
{
    Task CreateStatisticAsync(CreateStatisticDto createStatisticDto);
}