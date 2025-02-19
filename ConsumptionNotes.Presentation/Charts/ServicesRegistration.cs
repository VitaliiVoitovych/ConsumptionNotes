using Microsoft.Extensions.DependencyInjection;

namespace ConsumptionNotes.Presentation.Charts;

public static class ServicesRegistration
{
    public static IServiceCollection AddChartServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<ElectricityChartService>()
            .AddSingleton<NaturalGasChartService>();
    }
}