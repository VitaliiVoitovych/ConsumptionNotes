using System.Globalization;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using ConsumptionNotes.Dal.Extensions;
using ConsumptionNotes.Services.Files;
using ConsumptionNotes.Views;
using ConsumptionNotes.Views.Addition;

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
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            BindingPlugins.DataValidators.RemoveAt(0);
            var mainWindow = new MainWindow();
            Ioc.Default.ConfigureServices(ConfigureServices(mainWindow));
            
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static ServiceProvider ConfigureServices(Window window)
    {
        var services = new ServiceCollection();
        
        // DbContext
        services.AddConsumptionDbContext("Data Source=test.db");
        
        // Repositories
        services.AddRepositories();
        
        // Chart services 
        services.AddSingleton<ElectricityChartService>();
        services.AddSingleton<NaturalGasChartService>();
        
        // Note services
        services.AddSingleton<ElectricityNotesService>();
        services.AddSingleton<NaturalGasNotesService>();
        
        // Data Service
        services.AddSingleton<FileService>(d => new FileService(window));
        
        // View models
        services.AddTransient<HomeViewModel>();
        services.AddTransient<ElectricityViewModel>();
        services.AddTransient<NaturalGasViewModel>();
        
        services.AddScoped<ElectricityNoteViewModel>();
        services.AddScoped<NaturalGasNoteViewModel>();

        // Add views
        services.AddTransient<ElectricityNoteView>();
        services.AddTransient<NaturalGasNoteView>();
        
        return services.BuildServiceProvider();
    }
}