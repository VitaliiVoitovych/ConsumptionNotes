using ConsumptionNotes.Application.Commands.Base;
using ConsumptionNotes.Desktop.Controls.Dialogs;
using ConsumptionNotes.Desktop.Services.Files;

namespace ConsumptionNotes.Desktop.Commands;

public class ImportDataCommand(FileSystemService fileSystemService, Func<Stream, Task> importFromStream)
    : ImportDataCommandBase(importFromStream)
{
    protected override async Task<Stream> OpenFileAsync()
    {
        return await fileSystemService.OpenFileAsync("Виберіть файл для імпорту даних", FileServiceConstants.JsonFileType);
    }

    protected override async Task HandleFileNotSelectedException()
    {
        await MessageDialog.ShowAsync("Помилка", ExceptionMessages.FileNotSelectedExceptionMessage, MessageDialogIcon.Error);
    }

    protected override async Task HandleJsonException()
    {
        await MessageDialog.ShowAsync("Помилка", ExceptionMessages.JsonFileNotSelectedMessage, MessageDialogIcon.Error);
    }
}