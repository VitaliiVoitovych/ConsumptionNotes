using ConsumptionNotes.Desktop.Controls.Dialogs;
using ConsumptionNotes.Application.Services.Notes.Interfaces;
using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Desktop.ViewModels.Addition;

public abstract partial class ConsumptionNoteViewModelBase<TConsumption, TNotesService> : ViewModelBase
    where TConsumption : BaseConsumption
    where TNotesService : INotesService<TConsumption>
{
   
    
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
            await MessageDialog.ShowAsync("Помилка", ExceptionMessages.DuplicateNoteErrorMessage, MessageDialogIcon.Warning);
        }
        catch (InvalidConsumptionDataException)
        {
            await MessageDialog.ShowAsync("Помилка", ExceptionMessages.InvalidDateErrorMessage, MessageDialogIcon.Warning);
        }
    }
}