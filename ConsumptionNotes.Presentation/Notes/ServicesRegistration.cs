using ConsumptionNotes.Infrastructure.Notes;
using Microsoft.Extensions.DependencyInjection;

namespace ConsumptionNotes.Presentation.Notes;

public static class ServicesRegistration
{
    public static IServiceCollection AddObservableNotesService(this IServiceCollection services)
    {
        return services
            .AddNotesServices()
            .AddSingleton<ObservableElectricityNotesService>()
            .AddSingleton<ObservableNaturalGasNotesService>();
    }
}