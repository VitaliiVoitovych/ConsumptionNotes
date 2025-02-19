using ConsumptionNotes.Presentation.Commands.Base;
using ConsumptionNotes.Presentation.Notes.Services.Interfaces;

namespace ConsumptionNotes.Desktop.Commands;

public class ImportDataCommand<TConsumption, TObservableConsumption>(FileSystemService fileSystemService, IObservableNotesService<TConsumption, TObservableConsumption> notesService)
    : ImportDataCommandBase<TConsumption, TObservableConsumption>(notesService)
    where TConsumption : BaseConsumption
    where TObservableConsumption : ObservableBaseConsumption<TConsumption>
{
    protected override async Task<Stream> OpenFileAsync()
    {
        return await fileSystemService.OpenFileAsync("Виберіть файл для імпорту даних", FileServiceConstants.JsonFileType);
    }

    protected override async Task HandleFileNotSelectedException()
    {
        await MessageDialog.ShowAsync("Помилка", "Не було обрано файл", MessageDialogIcon.Error);
    }

    protected override async Task HandleJsonException()
    {
        await MessageDialog.ShowAsync("Помилка", "Не обрали потрібний файл з даними", MessageDialogIcon.Error);
    }
}