using System.Text.Json;
using ConsumptionNotes.Domain.Converters;

namespace ConsumptionNotes.Infrastructure;

public static class ConsumptionDataSerializer<TConsumption>
    where  TConsumption: ConsumptionBase
{
    private static readonly JsonSerializerOptions Options = new()
    {
        Converters = { new ConsumptionConverter<TConsumption>() }
    };

    public static async Task<IAsyncEnumerable<TConsumption>> DeserializeAsync(Stream stream)
    {
        var result = await JsonSerializer.DeserializeAsync<IAsyncEnumerable<TConsumption>>(stream, Options);
        return result ?? throw new InvalidOperationException("Failed to deserialize consumption data.");
    }

    public static async Task SerializeAsync(string path, IEnumerable<TConsumption> consumptions)
    {
        await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        await JsonSerializer.SerializeAsync(stream, consumptions);
    }
}