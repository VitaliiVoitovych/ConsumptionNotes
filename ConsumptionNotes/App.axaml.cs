using System.Globalization;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using ConsumptionNotes.Dal.Extensions;
using ConsumptionNotes.Services.Files;
using ConsumptionNotes.Views;
using ConsumptionNotes.Views.Addition;
using Microsoft.Extensions.Configuration;

namespace ConsumptionNotes;

public partial class App : Application
{
    private const string AppName = "ConsumptionNotes";
    private static IConfiguration? _configuration;
    
    public override void Initialize()
    {
        Name = AppName;
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Current!.RequestedThemeVariant = ThemeVariant.Dark;

        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .Build();
        
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

    private static string GetOrCreateDatabasePath()
    {
        var connectionString = _configuration?.GetConnectionString("DefaultConnection") ?? "temp.db";
        var appDatabaseFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppName);
        if (!Directory.Exists(appDatabaseFolderPath))
        {
            Directory.CreateDirectory(appDatabaseFolderPath);
        }
        
        return Path.Combine(appDatabaseFolderPath, connectionString);
    }
    
    private static ServiceProvider ConfigureServices(Window window)
    {
        // TODO: Refactoring Code, extract methods
        var services = new ServiceCollection();
        
        // DbContext
        var path = GetOrCreateDatabasePath();
        services.AddConsumptionDbContext($"Data Source={path}");
        
        // Repositories
        services.AddRepositories();
        
        // Chart services 
        services.AddSingleton<ElectricityChartService>();
        services.AddSingleton<NaturalGasChartService>();
        
        // Note services
        services.AddSingleton<ElectricityNotesService>();
        services.AddSingleton<NaturalGasNotesService>();
        
        // Data Service
        services.AddSingleton<FileService>(_ => new FileService(window));
        
        // View models
        services.AddTransient<HomeViewModel>();
        services.AddTransient<ElectricityDashboardViewModel>();
        services.AddTransient<NaturalGasDashboardViewModel>();
        
        services.AddScoped<ElectricityNoteViewModel>();
        services.AddScoped<NaturalGasNoteViewModel>();

        // Add views
        services.AddTransient<ElectricityNoteView>();
        services.AddTransient<NaturalGasNoteView>();
        
        return services.BuildServiceProvider();
    }
}