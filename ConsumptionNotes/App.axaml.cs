using System.Globalization;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using ConsumptionNotes.Views;

namespace ConsumptionNotes;
public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Current!.RequestedThemeVariant = ThemeVariant.Dark;
        
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("uk-UA");
        
        Ioc.Default.ConfigureServices(ConfigureServices());
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        
        // Chart services 
        services.AddSingleton<ElectricityChartService>();
        services.AddSingleton<NaturalGasChartService>();
        
        // Note services
        services.AddSingleton<ElectricityNotesService>();
        services.AddSingleton<NaturalGasNotesService>();
        
        // View models
        services.AddTransient<HomeViewModel>();
        services.AddTransient<ElectricityViewModel>();
        services.AddTransient<NaturalGasViewModel>();

        return services.BuildServiceProvider();
    }
}