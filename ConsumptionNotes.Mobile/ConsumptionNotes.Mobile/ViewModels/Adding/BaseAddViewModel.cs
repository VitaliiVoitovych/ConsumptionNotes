using ConsumptionNotes.Application.Services.Notes.Interfaces;
using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Mobile.ViewModels.Adding;

public abstract partial class BaseAddViewModel<TConsumption, TNotesService>(TNotesService notesService) 
    : ViewModelBase
    where TConsumption : BaseConsumption
    where TNotesService : INotesService<TConsumption>
{
    [ObservableProperty] private DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));
    
    private TNotesService _notesService = notesService;

    [RelayCommand]
    private async Task GoBack()
    {
        await Shell.Current.GoToAsync("..", true);
    }

    protected abstract decimal CalculateAmount();

    protected abstract TConsumption CreateConsumption();

    [RelayCommand]
    private async Task Add()
    {
        var consumption = CreateConsumption();
        try
        {
            InvalidConsumptionDataException.ThrowIfDateInvalid(consumption);
            _notesService.AddNote(consumption);
            UpdateDate();
        }
        catch (DuplicateConsumptionNoteException)
        {
            await Shell.Current.DisplayAlert("Помилка!", ExceptionMessages.DuplicateNoteErrorMessage, "Зрозуміло");
        }
        catch (InvalidConsumptionDataException)
        {
            await Shell.Current.DisplayAlert("Помилка!", ExceptionMessages.InvalidDateErrorMessage, "Зрозуміло");
        }
    }

    private void UpdateDate() => SelectedDate = SelectedDate.AddMonths(1);
}
