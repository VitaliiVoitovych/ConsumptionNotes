using ConsumptionNotes.Presentation.Commands.Base;

namespace ConsumptionNotes.Desktop.Commands;

public class ExportDataCommand<TConsumption>(FileSystemService fileSystemService)
    : ExportDataCommandBase<TConsumption>
    where TConsumption : ConsumptionBase
{
    public override async Task ExecuteAsync(IEnumerable<TConsumption>? collection)
    {
        if (collection is null) return;
        try
        {
            var folderPath = await fileSystemService.OpenFolderAsync("Виберіть папку для експорту даних");
            var filePath = await WriteToFile(folderPath, collection);
            await MessageDialog.ShowAsync("Дані успішно експортовано!", $"Дані експортовано за місцем \r\n{filePath}", MessageDialogIcon.Success);
        }
        catch (FolderNotSelectedException)
        {
            await MessageDialog.ShowAsync("Помилка", "Папка не була вибрана", MessageDialogIcon.Error);
        }
    }
}