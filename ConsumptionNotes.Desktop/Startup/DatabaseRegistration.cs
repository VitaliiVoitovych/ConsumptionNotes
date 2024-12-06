using ConsumptionNotes.Dal.Extensions;
using Microsoft.Extensions.Configuration;

namespace ConsumptionNotes.Desktop.Startup;

public static class DatabaseRegistration
{
    private static string GetOrCreateDatabasePath(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? "temp.db";
        var appDatabaseFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), App.AppName);
        if (!Directory.Exists(appDatabaseFolderPath))
        {
            Directory.CreateDirectory(appDatabaseFolderPath);
        }
        
        return Path.Combine(appDatabaseFolderPath, connectionString);
    }
    
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var path = GetOrCreateDatabasePath(configuration);
        return services.AddConsumptionDbContext($"Data Source={path}");
    }
}