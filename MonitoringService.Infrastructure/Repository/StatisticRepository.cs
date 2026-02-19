using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MonitoringService.Application.Repository;
using MonitoringService.Entities;
using MonitoringService.Infrastructure.Data;
using MonitoringService.Infrastructure.Repository.Base;

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
        await AddAsync(statistic);
    }

    public async Task<IEnumerable<Statistic>> GetAllStatisticsAsync()
    {
        return await GetAllAsync();
    }

    public async Task<IEnumerable<Statistic>> GetStatisticsByIdAsync(string deviceId)
    {
        return await _dbContext.Statistics.Where(s => s.DeviceId == deviceId).ToListAsync(); 
    }
}