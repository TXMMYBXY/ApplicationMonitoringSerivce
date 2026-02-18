using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MonitoringService.Api.Configuration;
using MonitoringService.Entities.Data;

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
        services.Configure<DataBaseConnectionSettings>(Configuration.GetSection("DataBaseConnectionSettings"));

        var dataBaseConnectionSettings = Configuration.GetSection("DataBaseConnectionSettings").Get<DataBaseConnectionSettings>();
        
        services.AddControllers();
        services.AddDbContext<AppclicationDBContext>(options =>
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
        // app.UseErrorHandling();
    
        app.UseHttpsRedirection();
    }
}