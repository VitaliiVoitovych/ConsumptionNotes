using CommunityToolkit.Mvvm.Input;

namespace ConsumptionNotes.Application.Commands.Interfaces;

public interface IAsyncCommand
{
    IAsyncRelayCommand Command { get; }
    Task ExecuteAsync();
}