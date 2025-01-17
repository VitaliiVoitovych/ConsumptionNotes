using ConsumptionNotes.Application.Commands.Base;

namespace ConsumptionNotes.Mobile.Commands;

public class GoToCommand(string route, bool animated = false) : AsyncCommandBase
{
    public override async Task ExecuteAsync() => await Shell.Current.GoToAsync(route, animated);
}