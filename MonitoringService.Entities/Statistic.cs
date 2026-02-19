using System.ComponentModel.DataAnnotations;
using MonitoringService.Entities.Base;

namespace MonitoringService.Entities;

public class Statistic : EntityBase
{
    [Required]
    public string DeviceId { get; set; } = "";
    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = "";
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    [Required]
    public string Version { get; set; } = "";
}