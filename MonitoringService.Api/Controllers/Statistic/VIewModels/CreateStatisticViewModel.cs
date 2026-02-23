using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace MonitoringService.Api.Controllers.Statistic.VIewModels;

public class CreateStatisticViewModel
{
    [Required]
    [JsonPropertyName("_id")]
    public string DeviceId { get; set; } = "";
    [Required]
    [MaxLength(255)]
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [Required]
    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; set; }
    [Required]
    [JsonPropertyName("endTime")]
    public DateTime EndTime
    {
        get => _endTime;
        set
        {
            if(!_isDateValid(StartTime, value))
            {
                throw new ArgumentException("Time is not valid.");
            }

            _endTime = value;
        }
    }
    
    [Required]
    [JsonPropertyName("version")]
    public string Version
    {
        get => _version;
        set
        {
            if (!_IsValidSemVer(value))
            {
                throw new ArgumentException("Version is not valid.");
            }
            
            _version = value;
        }
    }

    private DateTime _endTime;
    private string _version;
    
    private bool _isDateValid(DateTime startTime, DateTime endTime)
    {
        return startTime < endTime;
    }

    private bool _IsValidSemVer(string version)
    {
        var semVerRegex = new Regex(
            @"^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$",
            RegexOptions.Compiled);

        return semVerRegex.IsMatch(version);
    }
}