using MonitoringService.Application.Repository.Base;
using MonitoringService.Entities;

namespace MonitoringService.Application.Repository;

public interface IStatisticRepository : IBaseRepository<Statistic>
{
    /// <summary>
    /// Создать новую запись статистики
    /// </summary>
    /// <param name="statistic">Сущность статистики</param>
    Task CreateStatisticAsync(Statistic statistic);
    
    /// <summary>
    /// Вернуть все записи статистик
    /// </summary>
    /// <returns>List сущностей</returns>
    Task<IEnumerable<Statistic>> GetAllStatisticsAsync();
    
    /// <summary>
    /// Вернуть все записи для конкретного устройства
    /// </summary>
    /// <param name="deviceId">ID устройства</param>
    /// <returns>List сущностей</returns>
    Task<IEnumerable<Statistic>> GetStatisticsByIdAsync(string deviceId);

    Task<IEnumerable<string>> GetAllDevicesAsync();
}