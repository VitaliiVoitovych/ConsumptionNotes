using ConsumptionNotes.Application.Services.Notes.Interfaces;
using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Mobile.ViewModels.Addition;

public abstract partial class BaseAddViewModel<TConsumption, TNotesService>(TNotesService notesService) : ObservableObject
    where TConsumption : BaseConsumption
    where TNotesService : INotesService<TConsumption>
{
    [ObservableProperty] protected DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now);

    [RelayCommand]
    protected async Task GoBack()
    {
        await Shell.Current.GoToAsync("..", true);
    }

    protected abstract decimal CalculateAmount();

    protected abstract TConsumption CreateConsumption();

    [RelayCommand]
    protected async Task Add()
    {
        var consumption = CreateConsumption();
        try
        {
            InvalidConsumptionDataException.ThrowIfDateInvalid(consumption);
            notesService.AddNote(consumption);
            UpdateDate();
        }
        catch (DuplicateConsumptionNoteException)
        {
            await Shell.Current.DisplayAlert("Помилка!", "Запис про цей місяць вже є", "Зрозуміло");
        }
        catch (InvalidConsumptionDataException)
        {
            await Shell.Current.DisplayAlert("Помилка!", "Не можна додавати запис \r\nпро поточний чи майбутній місяць", "Зрозуміло");
        }
    }

    protected void UpdateDate() => SelectedDate = SelectedDate.AddMonths(1);
}
