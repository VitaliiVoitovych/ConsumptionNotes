using ConsumptionNotes.Views.Addition;

namespace ConsumptionNotes.Startup;

public static class ServiceRegistration
{
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        return services
            .AddTransient<ElectricityNoteView>()
            .AddTransient<NaturalGasNoteView>();
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        return services
            .AddTransient<HomeViewModel>()
            .AddTransient<ElectricityDashboardViewModel>()
            .AddTransient<NaturalGasDashboardViewModel>()
            // Addition view models
            .AddScoped<ElectricityNoteViewModel>()
            .AddScoped<NaturalGasNoteViewModel>();
    }

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