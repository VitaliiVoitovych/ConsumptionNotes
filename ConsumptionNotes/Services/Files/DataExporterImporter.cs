using System.Text.Json;
using ConsumptionNotes.Domain;

namespace ConsumptionNotes.Services.Files;

public static class DataExporterImporter
{
    public static async Task<IAsyncEnumerable<T>> ImportAsync<T>(Stream stream)
        where T : BaseConsumption
    {
        var options = new JsonSerializerOptions
        {
            Converters = { new ConsumptionConverter<T>() }
        };
        return (await JsonSerializer.DeserializeAsync<IAsyncEnumerable<T>>(stream, options))!;
        //return JsonSerializer.DeserializeAsync<IAsyncEnumerable<T>>(stream, options)!;
    }

    public static async Task ExportAsync<T>(string path, IEnumerable<T> collection)
    {
        await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        await JsonSerializer.SerializeAsync(stream, collection);
    }
}