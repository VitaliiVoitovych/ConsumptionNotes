using ConsumptionNotes.Dal.Extensions;

namespace ConsumptionNotes.Mobile.Startup;

public static class DatabaseRegistration
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        const string filename = "consumption.db";
        var connectionString = Path.Combine(FileSystem.Current.AppDataDirectory, filename);
        return services.AddConsumptionDbContext($"Data Source={connectionString}");
    }
}