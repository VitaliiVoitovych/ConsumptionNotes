using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Notes;
using Microsoft.Extensions.DependencyInjection;

namespace ConsumptionNotes.Application.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddChartServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<ElectricityChartService>()
            .AddSingleton<NaturalGasChartService>();
    }

    public static IServiceCollection AddNotesServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<ElectricityNotesService>()
            .AddSingleton<NaturalGasNotesService>();
    }
}
