using MonitoringService.Application.Repository;
using MonitoringService.Entities;
using MonitoringService.Entities.Data;

namespace MonitoringService.Infrastructure.Repository;

public class StatisticRepository : BaseRepository<Statistic>, IStatisticRepository
{
    private readonly AppclicationDBContext _dbContext;

    public StatisticRepository(AppclicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task CreateStatisticAsync(Statistic statistic)
    {
        await _dbContext.Statistics.AddAsync(statistic);
    }
}