using CommunityToolkit.Mvvm.Input;
using ConsumptionNotes.Application.Models;
using ConsumptionNotes.Application.Services.Notes.Interfaces;
using ConsumptionNotes.Application.ViewModels.Adding.Interfaces;
using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Application.ViewModels.Adding;

public abstract partial class BaseAddingViewModel<TConsumption, TObservableConsumption, TNotesService>(TNotesService notesService) 
    : ViewModelBase, IAddingViewModel
    where TConsumption : BaseConsumption
    where TObservableConsumption : ObservableBaseConsumption<TConsumption>
    where TNotesService : INotesService<TConsumption, TObservableConsumption>
{
    private TNotesService _notesService = notesService;
    
    [ObservableProperty] private DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));
    
    public required AsyncRelayCommand AddNoteCommand { get; init; }
    
    protected abstract TConsumption CreateConsumption();

    protected void AddNote()
    {
        var consumption = CreateConsumption();
        InvalidConsumptionDataException.ThrowIfDateInvalid(consumption);
        _notesService.AddNote(consumption);
        UpdateDate();
    }
    
    private void UpdateDate() => SelectedDate = SelectedDate.AddMonths(1);
}