using ConsumptionNotes.Presentation.Commands.Base;
using ConsumptionNotes.Presentation.Notes.Services.Interfaces;

namespace ConsumptionNotes.Mobile.Commands;

public class ImportDataCommand<TConsumption, TObservableConsumption>(FileSystemService fileSystemService, IObservableNotesService<TConsumption, TObservableConsumption> notesService)
    : ImportDataCommandBase<TConsumption, TObservableConsumption>(notesService)
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
{
    protected override async Task<Stream> OpenFileAsync()
    {
        return await fileSystemService.OpenFileAsync(FileServiceConstants.JsonPickOptions, "Виберіть файл з даними .json");
    }

    protected override async Task HandleFileNotSelectedException()
    {
        await Shell.Current.DisplayAlert("Помилка!", "Не було обрано файл", "Зрозуміло");
    }

    protected override async Task HandleJsonException()
    {
        await Shell.Current.DisplayAlert("Помилка!", "Папка не була вибрана", "Зрозуміло");
    }

    protected override async Task HandleInvalidOperationException()
    {
        await Shell.Current.DisplayAlert("Помилка!", "Не вдалося прочитати дані", "Зрозуміло");
    }
}