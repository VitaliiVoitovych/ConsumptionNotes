using System.Threading;
using Avalonia.Media;
using FluentAvalonia.UI.Windowing;

namespace ConsumptionNotes.Views.SplashScreen;

public class ComplexSplashScreen : IApplicationSplashScreen
{
    public ComplexSplashScreen()
    {
        SplashScreenContent = new SplashScreenView();
    }
    
    public async Task RunTasks(CancellationToken cancellationToken)
    {
        await ((SplashScreenView)SplashScreenContent).InitApp();
    }

    public string AppName => "";
    public IImage? AppIcon => null;
    public object SplashScreenContent { get; }
    public int MinimumShowTime => 0;
}