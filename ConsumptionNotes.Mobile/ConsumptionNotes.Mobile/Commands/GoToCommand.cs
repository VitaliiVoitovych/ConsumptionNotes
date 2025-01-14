namespace ConsumptionNotes.Mobile.Commands;

public class GoToCommand(string route, bool animated = false)
{
    private IAsyncRelayCommand? _command;
    public IAsyncRelayCommand Command => _command ??= new AsyncRelayCommand(GoToAsync);

    private async Task GoToAsync() => await Shell.Current.GoToAsync(route, animated);
}