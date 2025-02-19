using ConsumptionNotes.Infrastructure.Notes.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsumptionNotes.Infrastructure.Notes;

public static class ServicesRegistration
{
    public static IServiceCollection AddNotesServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<ElectricityNotesService>()
            .AddSingleton<NaturalGasNotesService>();
    }
}