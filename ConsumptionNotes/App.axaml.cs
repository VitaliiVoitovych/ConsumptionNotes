using System.Globalization;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Avalonia.Styling;
using ConsumptionNotes.Dal.Extensions;
using ConsumptionNotes.Services.Files;
using ConsumptionNotes.Startup;
using ConsumptionNotes.Views;
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

        // TODO: Extract method
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .Build();
        
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("uk-UA");
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            BindingPlugins.DataValidators.RemoveAt(0);
            var mainWindow = new MainWindow();
            Ioc.Default.ConfigureServices(ConfigureServices(mainWindow.StorageProvider));
            
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }

    // TODO: Move to another place
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
    
    private static ServiceProvider ConfigureServices(IStorageProvider storageProvider)
    {
        var services = new ServiceCollection();
        // TODO: Improve method
        // DbContext
        var path = GetOrCreateDatabasePath();
        services.AddConsumptionDbContext($"Data Source={path}");
        
        // File Service
        services.AddSingleton<FileService>(_ => new FileService(storageProvider));
        
        services
            .AddRepositories()
            .AddChartServices()
            .AddNotesServices()
            .AddViewModels()
            .AddViews();
        
        return services.BuildServiceProvider();
    }
}