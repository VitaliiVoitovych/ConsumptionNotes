﻿using ConsumptionNotes.Application.ViewModels.Adding;
using ConsumptionNotes.Mobile.Commands;

namespace ConsumptionNotes.Mobile.ViewModels.Adding;

public class ElectricityAddingViewModel : BaseElectricityAddingViewModel
{
    public GoToCommand GoToBackCommand { get; } = new("..", true);

    public AddNoteCommand AddNoteCommand { get; }

    public ElectricityAddingViewModel(ElectricityNotesService notesService) : base(notesService)
    {
        AddNoteCommand = new AddNoteCommand(AddNote);
    }
}
