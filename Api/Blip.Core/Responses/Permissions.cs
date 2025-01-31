﻿namespace Blip.Core.Responses;
using System.Text.Json.Serialization;

public class Permissions
{
    [JsonPropertyName("admin")]
    public bool? Admin { get; set; }

    [JsonPropertyName("maintain")]
    public bool? Maintain { get; set; }

    [JsonPropertyName("push")]
    public bool? Push { get; set; }

    [JsonPropertyName("triage")]    
    public bool? Triage { get; set; }

    [JsonPropertyName("pull")]
    public bool? Pull { get; set; }
 }