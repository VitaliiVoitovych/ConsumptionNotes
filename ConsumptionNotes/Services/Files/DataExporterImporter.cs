using System.IO;
using System.Text.Json;

namespace ConsumptionNotes.Services.Files;

public static class DataExporterImporter
{
    public static IAsyncEnumerable<T> Import<T>(Stream stream)
    {
        return JsonSerializer.DeserializeAsyncEnumerable<T>(stream)!;
    }

    public static async Task ExportAsync<T>(string path, IEnumerable<T> collection)
    {
        await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        await JsonSerializer.SerializeAsync(stream, collection);
    }
}