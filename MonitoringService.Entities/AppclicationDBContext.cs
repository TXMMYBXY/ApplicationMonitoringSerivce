using Microsoft.EntityFrameworkCore;

namespace MonitoringService.Entities;

public class AppclicationDBContext : DbContext
{
    public AppclicationDBContext(DbContextOptions<AppclicationDBContext> options)
    : base(options)
    {
    }
    
    public DbSet<Statistic> Statistics { get; set; }
    
}