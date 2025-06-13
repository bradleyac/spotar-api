using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpotAR.API;

public class AltJsonConverter : JsonConverter<float>
{
    public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TryGetSingle(out float value)) return value; else return 0f;
    }

    public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}
