using System.Text.Json;
using ConsumptionNotes.Application.Commands.Base;
using ConsumptionNotes.Domain.Exceptions;
using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.Commands;

public class ImportDataCommand(FileSystemService fileSystemService, Func<Stream, Task> importFromStream)
    : ImportDataCommandBase(importFromStream)
{
    protected override async Task<Stream> OpenFileAsync()
    {
        return await fileSystemService.OpenFileAsync(FileServiceConstants.JsonPickOptions, "Виберіть файл з даними .json");
    }

    protected override async Task HandleFileNotSelectedException()
    {
        await Shell.Current.DisplayAlert("Помилка!", ExceptionMessages.FileNotSelectedExceptionMessage, "Зрозуміло");
    }

    protected override async Task HandleJsonException()
    {
        await Shell.Current.DisplayAlert("Помилка!", ExceptionMessages.JsonFileNotSelectedMessage, "Зрозуміло");
    }
}