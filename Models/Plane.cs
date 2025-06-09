using System.Text.Json.Serialization;

namespace SpotAR.API.Models;

public class Plane
{
    [JsonPropertyName("flight")]
    public string Flight { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object> Extras { get; set; } = [];
}