using MonitoringService.Entities;

namespace MonitoringService.Application.Repository;

public interface IStatisticRepository : IBaseRepository<Statistic>
{
    Task CreateStatisticAsync(Statistic statistic);
}