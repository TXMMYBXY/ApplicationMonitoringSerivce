namespace ApplicationMonitoringService.Application.Service.Dto;

public class CreateStatisticDto
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Version { get; set; } = "";
}