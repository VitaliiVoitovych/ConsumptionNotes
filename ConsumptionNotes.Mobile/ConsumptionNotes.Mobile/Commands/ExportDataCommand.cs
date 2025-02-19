using ConsumptionNotes.Presentation.Commands.Base;

namespace ConsumptionNotes.Mobile.Commands;

public class ExportDataCommand<TConsumption>(FileSystemService fileSystemService, string exportFilename)
    : ExportDataCommandBase<TConsumption>(exportFilename)
    where TConsumption : BaseConsumption
{
    public override async Task ExecuteAsync(IEnumerable<TConsumption>? collection)
    {
        var filePath = await WriteToFile(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), collection);
        
        await fileSystemService.ShareFileAsync(filePath, "Експортувати дані");
        if(File.Exists(filePath)) File.Delete(filePath);
    }
}