using MonitoringService.Application.Service.StatisticService.Dto;

namespace MonitoringService.Application.Service.StatisticService;

public interface IStatisticService
{
    /// <summary>
    /// Создание статистики
    /// </summary>
    /// <param name="createStatisticDto">DTO с данными</param>
    Task CreateStatisticAsync(CreateStatisticDto createStatisticDto);
    
    /// <summary>
    /// Вернуть всю статистику
    /// </summary>
    Task<IReadOnlyCollection<GetStatisticDto>> GetAllStatisticsAsync();
    
    /// <summary>
    /// Вернуть всю статистику для одного устройства
    /// </summary>
    /// <param name="deviceId">ID устройства</param>
    Task<IReadOnlyCollection<GetStatisticDto>> GetStatisticsByIdAsync(string deviceId);

    Task<IReadOnlyCollection<GetDeviceDto>> GetAllDevicesAsync();
    Task DeleteStatisticByIdAsync(int statisticId);
}