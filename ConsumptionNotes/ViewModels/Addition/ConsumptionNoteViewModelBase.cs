using ConsumptionNotes.Domain.Exceptions;
using ConsumptionNotes.Services.Notes.Interfaces;
using ConsumptionNotes.Utils.Dialogs;

namespace ConsumptionNotes.ViewModels.Addition;

public abstract partial class ConsumptionNoteViewModelBase<TConsumption, TNotesService> : ViewModelBase
    where TConsumption : BaseConsumption
    where TNotesService : INotesService<TConsumption>
{
    private const string DuplicateNoteErrorMessage  = "Запис про цей місяць вже є";
    private const string InvalidDateErrorMessage = "Не можна додавати запис \r\nпро поточний чи майбутній місяць";
    
    [ObservableProperty] private DateTimeOffset _selectedDate = DateTimeOffset.Now;

    private TNotesService _notesService;
    
    protected ConsumptionNoteViewModelBase(TNotesService notesService)
    {
        _notesService = notesService;
    }
    
    protected abstract decimal CalculateAmount();

    protected abstract TConsumption CreateConsumption();
    
    private void UpdateDate()
    {
        SelectedDate = SelectedDate.AddMonths(1);
    }

    [RelayCommand]
    private async Task Add()
    {
        var consumption = CreateConsumption();
        
        try
        {
            InvalidConsumptionDataException.ThrowIfDateInvalid(consumption); // TODO: Improve
            _notesService.AddNote(consumption);
            UpdateDate();
        }
        catch (DuplicateConsumptionNoteException)
        {
            await Dialogs.ShowMessageDialog("Помилка", DuplicateNoteErrorMessage);
        }
        catch (InvalidConsumptionDataException)
        {
            await Dialogs.ShowMessageDialog("Помилка", InvalidDateErrorMessage);
        }
    }
}