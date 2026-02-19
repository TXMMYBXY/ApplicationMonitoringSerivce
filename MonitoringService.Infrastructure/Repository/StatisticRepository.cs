using MonitoringService.Application.Repository;
using MonitoringService.Entities;
using MonitoringService.Infrastructure.Data;

namespace MonitoringService.Infrastructure.Repository;

public class StatisticRepository : BaseRepository<Statistic>, IStatisticRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StatisticRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task CreateStatisticAsync(Statistic statistic)
    {
        await _dbContext.Statistics.AddAsync(statistic);
    }
}