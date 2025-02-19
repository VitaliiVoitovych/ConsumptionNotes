namespace ConsumptionNotes.Presentation.Commands.Interfaces;

public interface IAsyncCommand
{
    IAsyncRelayCommand Command { get; }
    Task ExecuteAsync();
}

public interface IAsyncCommand<in T>
{
    IAsyncRelayCommand<T> Command { get; }
    Task ExecuteAsync(T? obj);
}