using System.Text.Json;
using ConsumptionNotes.Desktop.Controls.Dialogs;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Desktop.Commands;

public class ImportDataCommand(FileSystemService fileSystemService, Func<Stream, Task> importFromStream)
{
    private IAsyncRelayCommand? _command;
    
    public IAsyncRelayCommand Command => _command ??= new AsyncRelayCommand(Import);

    private async Task Import()
    {
        try
        {
            await using var file = await fileSystemService.OpenFileAsync("Виберіть файл для імпорту даних", FileServiceConstants.JsonFileType);
            await importFromStream.Invoke(file);
        }
        catch (FileNotSelectedException)
        {
            await MessageDialog.ShowAsync("Помилка", ExceptionMessages.FileNotSelectedExceptionMessage, MessageDialogIcon.Error);
        }
        catch (JsonException)
        {
            await MessageDialog.ShowAsync("Помилка", ExceptionMessages.JsonFileNotSelectedMessage, MessageDialogIcon.Error);
        }
    }
}