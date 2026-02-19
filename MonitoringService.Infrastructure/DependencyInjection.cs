using Microsoft.Extensions.DependencyInjection;
using MonitoringService.Application.Repository;
using MonitoringService.Application.Service;
using MonitoringService.Infrastructure.Repository;
using MonitoringService.Infrastructure.Service;

namespace MonitoringService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IStatisticRepository, StatisticRepository>();
        services.AddScoped<IStatisticService, StatisticService>();

        return services;
    }
}