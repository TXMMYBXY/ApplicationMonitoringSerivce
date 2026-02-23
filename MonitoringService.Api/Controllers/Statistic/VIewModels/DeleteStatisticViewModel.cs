using System.Text.Json.Serialization;

namespace MonitoringService.Api.Controllers.Statistic.VIewModels;

public class DeleteStatisticViewModel
{
    [JsonPropertyName(("id"))]
    public int Id { get; set; }
}