using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using ConsumptionNotes.Views;
using Microsoft.Extensions.Hosting;

namespace ConsumptionNotes;
public partial class App : Application
{
    public static IHost Host { get; private set; }
    
    public override void Initialize()
    {
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureServices(ConfigureServices)
            .Build();
        
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

    private void ConfigureServices(IServiceCollection services)
    {
        // Added view models
        services.AddTransient<HomeViewModel>();
        services.AddTransient<ElectricityViewModel>();
        services.AddTransient<NaturalGasViewModel>();
    }
}