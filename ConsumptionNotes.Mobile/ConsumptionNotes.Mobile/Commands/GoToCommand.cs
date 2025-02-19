using ConsumptionNotes.Presentation.Commands.Base;

namespace ConsumptionNotes.Mobile.Commands;

public class GoToCommand(string route, bool animate = false) : AsyncCommandBase
{
    public override async Task ExecuteAsync() => await Shell.Current.GoToAsync(route, animate);
}

public class GoToCommand<T>(string route, string paramsName, bool animate = false)
    : AsyncCommandBase<T>
{
    public override async Task ExecuteAsync(T? obj)
    {
        if (obj is null) return;

        await Shell.Current.GoToAsync(route, animate, new Dictionary<string, object>
        {
            {paramsName, obj}
        });
    }
}