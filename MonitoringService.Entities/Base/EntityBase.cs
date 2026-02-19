using System.ComponentModel.DataAnnotations;

namespace MonitoringService.Entities.Base;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
}