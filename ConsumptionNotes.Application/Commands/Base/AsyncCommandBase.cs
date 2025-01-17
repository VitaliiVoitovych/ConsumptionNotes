using CommunityToolkit.Mvvm.Input;
using ConsumptionNotes.Application.Commands.Interfaces;

namespace ConsumptionNotes.Application.Commands.Base;

public abstract class AsyncCommandBase : IAsyncCommand
{
    private IAsyncRelayCommand? _command;

    public IAsyncRelayCommand Command => _command ??= new AsyncRelayCommand(ExecuteAsync);
    
    public abstract Task ExecuteAsync();

    public static implicit operator AsyncRelayCommand(AsyncCommandBase command)
    {
        return (AsyncRelayCommand)command.Command;
    }
}