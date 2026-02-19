namespace MonitoringService.Application.Service.StatisticService.Dto;

public class GetStatisticDto
{
    public string DeviceId { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Version { get; set; }
}