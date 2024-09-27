using ConsumptionNotes.Services.Notes.Interfaces;
using ConsumptionNotes.Utils.Dialogs;

namespace ConsumptionNotes.ViewModels.Addition;

public abstract partial class ConsumptionNoteViewModelBase<TConsumption, TNotesService> : ViewModelBase
    where TConsumption : BaseConsumption
    where TNotesService : INotesService<TConsumption>
{
    [ObservableProperty] private DateTimeOffset _selectedDate = DateTimeOffset.UtcNow;

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
            _notesService.AddNote(consumption);
            UpdateDate();
        }
        catch (ArgumentException ex)
        {
            var messageDialog = Dialogs.CreateMessageDialog("Помилка", ex.Message);
            await messageDialog.ShowAsync();
        }
    }
}