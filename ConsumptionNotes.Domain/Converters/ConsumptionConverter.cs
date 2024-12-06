using System.Text.Json;
using System.Text.Json.Serialization;
using ConsumptionNotes.Domain.Models;

namespace ConsumptionNotes.Domain.Converters;

public class ConsumptionConverter<T> : JsonConverter<T>
    where T : BaseConsumption
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        
        if (typeToConvert == typeof(ElectricityConsumption) && root.TryGetProperty(nameof(ElectricityConsumption.DayKilowattConsumed), out _))
        {
            return JsonSerializer.Deserialize<T>(root.GetRawText());
        }
        
        if (typeToConvert == typeof(NaturalGasConsumption) && root.TryGetProperty(nameof(NaturalGasConsumption.CubicMeterConsumed), out _))
        {
            return JsonSerializer.Deserialize<T>(root.GetRawText());
        }
        
        throw new JsonException("Wrong consumption type");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}