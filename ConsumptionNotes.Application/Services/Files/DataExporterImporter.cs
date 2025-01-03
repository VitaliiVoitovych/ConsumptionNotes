using ConsumptionNotes.Domain.Converters;
using System.Text.Json;

namespace ConsumptionNotes.Application.Services.Files;

public static class DataExporterImporter<T>
    where T : BaseConsumption
{
    private static readonly JsonSerializerOptions Options = new()
    {
        Converters = { new ConsumptionConverter<T>()}
    };

    public static async Task<IAsyncEnumerable<T>> ImportAsync(Stream stream)
    {
        return (await JsonSerializer.DeserializeAsync<IAsyncEnumerable<T>>(stream, Options))!;
    }

    public static async Task ExportAsync(string path, IEnumerable<T> collection)
    {
        await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        await JsonSerializer.SerializeAsync(stream, collection);
    }
}
