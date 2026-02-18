using MonitoringService.Application.Service.Dto;

namespace MonitoringService.Application.Service;

public interface IStatisticService
{
    Task CreateStatisticAsync(CreateStatisticDto createStatisticDto);
}