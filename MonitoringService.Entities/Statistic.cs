using System.ComponentModel.DataAnnotations;

namespace MonitoringService.Entities;

public class Statistic
{
    [Required]
    public string Id { get; set; } = "";
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