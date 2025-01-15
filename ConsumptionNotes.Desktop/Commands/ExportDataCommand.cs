using ConsumptionNotes.Desktop.Controls.Dialogs;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Desktop.Commands;

public class ExportDataCommand(FileSystemService fileSystemService, Func<string, Task<string>> writeToFile)
{
    private IAsyncRelayCommand? _command;
    
    public IAsyncRelayCommand Command => _command ??= new AsyncRelayCommand(Export);

    private async Task Export()
    {
        try
        {
            var folderPath = await fileSystemService.OpenFolderAsync("Виберіть папку для експорту даних");
            var filePath = await writeToFile.Invoke(folderPath);
            await MessageDialog.ShowAsync("Дані успішно експортовано!", $"Дані експортовано за місцем \r\n{filePath}", MessageDialogIcon.Success);
        }
        catch (FolderNotSelectedException)
        {
            await MessageDialog.ShowAsync("Помилка", ExceptionMessages.FolderNotSelectedExceptionMessage, MessageDialogIcon.Error);
        }
    }
}