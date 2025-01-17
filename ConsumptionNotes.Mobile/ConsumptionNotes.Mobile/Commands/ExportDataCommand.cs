using ConsumptionNotes.Application.Commands.Base;
using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.Commands;

public class ExportDataCommand(FileSystemService fileSystemService, Func<string, Task<string>> writeToFile)
    : AsyncCommandBase
{
    public override async Task ExecuteAsync()
    {
        var filePath = await writeToFile.Invoke(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        
        await fileSystemService.ShareFileAsync(filePath, "Експортувати дані");
        if(File.Exists(filePath)) File.Delete(filePath);
    }
}