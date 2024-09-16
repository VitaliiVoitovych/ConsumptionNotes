using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using ConsumptionNotes.Services.Charting;
using ConsumptionNotes.Views;

namespace ConsumptionNotes;
public partial class App : Application
{
    public override void Initialize()
    {
        Ioc.Default.ConfigureServices(ConfigureServices());
        
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        
        // Added view models
        services.AddTransient<HomeViewModel>();
        services.AddTransient<ElectricityViewModel>();
        services.AddTransient<NaturalGasViewModel>();

        return services.BuildServiceProvider();
    }
}