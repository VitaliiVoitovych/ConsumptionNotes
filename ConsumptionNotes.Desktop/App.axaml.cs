using System.Globalization;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Avalonia.Styling;
using ConsumptionNotes.Dal.Extensions;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Desktop.Views;
using ConsumptionNotes.Desktop.Startup;
using Microsoft.Extensions.Configuration;

namespace ConsumptionNotes.Desktop;

public partial class App : Avalonia.Application
{
    public const string AppName = "ConsumptionNotes";
    private static IConfiguration? _configuration;
    
    public override void Initialize()
    {
        Name = AppName;
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Current!.RequestedThemeVariant = ThemeVariant.Dark;
        
        _configuration = InitializeConfiguration();
        
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

    private static IConfiguration InitializeConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .Build();
    }
    
    private static ServiceProvider ConfigureServices(IStorageProvider storageProvider)
    {
        var services = new ServiceCollection();
        
        services.AddDatabase(_configuration!);
        
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