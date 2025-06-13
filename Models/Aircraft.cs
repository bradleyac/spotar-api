using System.Text.Json.Serialization;

namespace SpotAR.API.Models;

public class Aircraft
{
    [JsonPropertyName("flight")]
    public string Flight { get; set; } = "UNKNOWN";
    [JsonPropertyName("lat")]
    public float Latitude { get; set; }
    [JsonPropertyName("lon")]
    public float Longitude { get; set; }
    [JsonConverter(typeof(AltJsonConverter))]
    [JsonPropertyName("alt_geom")]
    public float? AltGeomFt { get; set; }
    [JsonConverter(typeof(AltJsonConverter))]
    [JsonPropertyName("alt_baro")]
    public float? AltBaroFt { get; set; }
}