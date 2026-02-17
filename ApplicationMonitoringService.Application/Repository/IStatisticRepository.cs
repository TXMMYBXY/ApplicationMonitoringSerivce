using ApplicationMonitoringService.Entities;

namespace ApplicationMonitoringService.Application.Repository;

public interface IStatisticRepository : IBaseRepository<Statistic>
{
    Task CreateStatisticAsync(Statistic statistic);
}