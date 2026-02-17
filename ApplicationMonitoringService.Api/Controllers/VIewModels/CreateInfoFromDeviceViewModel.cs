using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApplicationMonitoringService.Api.Controllers.VIewModels;

public class CreateInfoFromDeviceViewModel
{
    [JsonPropertyName("_id")]
    public string Id { get; set; } = "";
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