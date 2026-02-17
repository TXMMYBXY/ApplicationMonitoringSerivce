using Microsoft.EntityFrameworkCore;

namespace ApplicationMonitoringService.Entities;

public class AppclicationDBContext : DbContext
{
    public AppclicationDBContext(DbContextOptions<AppclicationDBContext> options)
    : base(options)
    {
    }
    
    public DbSet<Statistic> Statistics { get; set; }
    
}