namespace MonitoringService.Api.Controllers.Statistic.VIewModels;

public class GetStatisticViewModel
{
    public int Id { get; set; }
    public string DeviceId { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Version { get; set; }
}