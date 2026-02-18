using MonitoringService.Api;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();


app.UseCors("AllowAll");

startup.Configure(app, app.Environment);

app.MapSwagger("/openapi/{documentName}.json");
app.MapScalarApiReference();
app.MapControllers();

app.Run();
