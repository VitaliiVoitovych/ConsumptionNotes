using ConsumptionNotes.Dal.Repositories;

namespace ConsumptionNotes.Dal.Extensions;

public static class RepositoryService
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<ElectricityConsumptionRepository>()
            .AddScoped<NaturalGasConsumptionRepository>();

        return services;
    }
}