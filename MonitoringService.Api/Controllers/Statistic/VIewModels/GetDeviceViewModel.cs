using System.Text.Json.Serialization;

namespace MonitoringService.Api.Controllers.Statistic.VIewModels;

public class GetDeviceViewModel
{
    [JsonPropertyName("_id")]
    public string DeviceId { get; set; }
}