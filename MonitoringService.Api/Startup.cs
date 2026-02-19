using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MonitoringService.Api.Configuration;
using MonitoringService.Api.Middleware;
using MonitoringService.Application.Repository;
using MonitoringService.Application.Service;
using MonitoringService.Infrastructure;
using MonitoringService.Infrastructure.Data;

namespace MonitoringService.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddInfrastructure();     
        
        
        services.Configure<DataBaseConnectionSettings>(Configuration.GetSection("DataBaseConnectionSettings"));

        var dataBaseConnectionSettings = Configuration.GetSection("DataBaseConnectionSettings").Get<DataBaseConnectionSettings>();
        
        services.AddControllers();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(dataBaseConnectionSettings.ConnectionString);
        });
        services.AddAutoMapper(typeof(Program));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Сервис мониторинга стороннего приложения",
                Version = "v1"
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseErrorHandling();
        app.UseHttpsRedirection();
    }
}