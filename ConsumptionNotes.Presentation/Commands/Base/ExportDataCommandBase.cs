namespace ConsumptionNotes.Presentation.Commands.Base;

public abstract class ExportDataCommandBase<TConsumption>(string exportFilename) : AsyncCommandBase<IEnumerable<TConsumption>>
    where TConsumption : ConsumptionBase
{
    protected async Task<string> WriteToFile(string folderPath, IEnumerable<TConsumption> collection)
    {
        var filename = $"{exportFilename}_{DateTime.UtcNow:dd-MM-yyyy}.json";
        var filePath = Path.Combine(folderPath, filename);

        await ConsumptionDataSerializer<TConsumption>.SerializeAsync(filePath, collection);
        
        return filePath;
    }
}