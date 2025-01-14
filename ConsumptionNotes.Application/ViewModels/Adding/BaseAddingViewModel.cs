﻿using ConsumptionNotes.Application.Services.Notes.Interfaces;
using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Application.ViewModels.Adding;

public abstract partial class BaseAddingViewModel<TConsumption, TNotesService>(TNotesService notesService) : ViewModelBase
    where TConsumption : BaseConsumption
    where TNotesService : INotesService<TConsumption>
{
    private TNotesService _notesService = notesService;
    
    [ObservableProperty] private DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));
    
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