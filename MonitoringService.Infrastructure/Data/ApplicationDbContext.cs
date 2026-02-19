using Microsoft.EntityFrameworkCore;
using MonitoringService.Entities;

namespace MonitoringService.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
    
    public DbSet<Statistic> Statistics { get; set; }
    
}