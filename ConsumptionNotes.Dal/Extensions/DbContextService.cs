namespace ConsumptionNotes.Dal.Extensions;

public static class DbContextService
{
    public static IServiceCollection AddConsumptionDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ConsumptionNotesDbContext>(options => options.UseSqlite(connectionString));

        return services;
    }
}