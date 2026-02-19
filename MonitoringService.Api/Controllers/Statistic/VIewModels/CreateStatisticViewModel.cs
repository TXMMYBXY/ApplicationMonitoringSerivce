using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MonitoringService.Api.Controllers.Statistic.VIewModels;

public class CreateStatisticViewModel
{
    [JsonPropertyName("_id")]
    public string DeviceId { get; set; } = "";
    [MaxLength(255)]
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; set; }
    [JsonPropertyName("endTime")]
    public DateTime EndTime { get; set; }
    [JsonPropertyName("version")]
    public string Version { get; set; } = "";
}