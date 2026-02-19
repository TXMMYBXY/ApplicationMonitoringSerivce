using Microsoft.EntityFrameworkCore;
using MonitoringService.Application.Repository;
using MonitoringService.Infrastructure.Data;

namespace MonitoringService.Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationDbContext _dbContext;
    protected readonly DbSet<T> _dbset;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbset = dbContext.Set<T>();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}