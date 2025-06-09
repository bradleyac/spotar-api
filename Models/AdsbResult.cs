using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace SpotAR.API.Models;

public class AdsbResult
{
    [JsonPropertyName("ac")]
    public List<Plane> Planes { get; set; } = [];
    [JsonPropertyName("msg")]
    public string? Message { get; set; }
    [JsonPropertyName("total")]
    public int Total { get; set; }
}