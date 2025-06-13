using System.Text.Json.Serialization;

namespace SpotAR.API.Models;

public class Aircraft
{
    [JsonPropertyName("flight")]
    public required string Flight { get; set; }
    [JsonPropertyName("lat")]
    public float Latitude { get; set; }
    [JsonPropertyName("lon")]
    public float Longitude { get; set; }
    [JsonPropertyName("alt_geom")]
    public string? AltGeomFt { get; set; }
    [JsonPropertyName("alt_baro")]
    public string? AltBaroFt { get; set; }
}