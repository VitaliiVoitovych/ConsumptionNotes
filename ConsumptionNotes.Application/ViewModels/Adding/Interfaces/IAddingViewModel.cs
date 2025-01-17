using CommunityToolkit.Mvvm.Input;

namespace ConsumptionNotes.Application.ViewModels.Adding.Interfaces;

public interface IAddingViewModel
{
    AsyncRelayCommand AddNoteCommand { get; }
}