using Microsoft.OpenApi.Models;

namespace ApplicationMonitoringService.Api;

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
        // services.AddDbContext<ApplicationDbContext>();

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