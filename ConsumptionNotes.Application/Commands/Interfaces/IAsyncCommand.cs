using CommunityToolkit.Mvvm.Input;

namespace ConsumptionNotes.Application.Commands.Interfaces;

public interface IAsyncCommand
{
    IAsyncRelayCommand Command { get; }
    Task ExecuteAsync();
}

public interface IAsyncCommand<T>
{
    IAsyncRelayCommand<T> Command { get; }
    Task ExecuteAsync(T? obj);
}