using System.Text.Json.Serialization;

namespace MonitoringService.Api.Controllers.Statistic.VIewModels;

public class GetStatisticViewModel
{
    public int Id { get; set; }
    [JsonPropertyName("_id")]
    public string DeviceId { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Version { get; set; }
}