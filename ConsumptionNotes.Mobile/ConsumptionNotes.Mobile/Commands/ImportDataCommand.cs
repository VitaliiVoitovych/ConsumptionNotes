using System.Text.Json;
using ConsumptionNotes.Domain.Exceptions;
using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.Commands;

public class ImportDataCommand(FileSystemService fileSystemService, Func<Stream, Task> importFromStream)
{
    private IAsyncRelayCommand? _command;
    
    public IAsyncRelayCommand Command => _command ??= new AsyncRelayCommand(Import);

    private async Task Import()
    {
        try
        {
            await using var file = await fileSystemService.OpenFileAsync(FileServiceConstants.JsonPickOptions, "Виберіть файл з даними .json");
            await importFromStream.Invoke(file);
        }
        catch (FileNotSelectedException)
        {
            await Shell.Current.DisplayAlert("Помилка!", ExceptionMessages.FileNotSelectedExceptionMessage, "Зрозуміло");
        }
        catch (JsonException)
        {
            await Shell.Current.DisplayAlert("Помилка!", ExceptionMessages.JsonFileNotSelectedMessage, "Зрозуміло");
        }
    }
}