using ConsumptionNotes.Application.Commands.Base;

namespace ConsumptionNotes.Mobile.Commands;

public class GoToCommand(string route, bool animate = false) : AsyncCommandBase
{
    public override async Task ExecuteAsync() => await Shell.Current.GoToAsync(route, animate);
}