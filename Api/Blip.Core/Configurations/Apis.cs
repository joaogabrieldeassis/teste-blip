using System.ComponentModel.DataAnnotations;

namespace Blip.Core.Configurations;

public class Apis
{
    [Required]
    public string UrlGithubBlip { get; set; } = string.Empty;
}