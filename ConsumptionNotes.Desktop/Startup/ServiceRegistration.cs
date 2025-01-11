using ConsumptionNotes.Desktop.Views.Adding;

namespace ConsumptionNotes.Desktop.Startup;

public static class ServiceRegistration
{
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        // Adding views
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
            // Adding view models
            .AddScoped<ElectricityAddViewModel>()
            .AddScoped<NaturalGasAddViewModel>();
    }
}