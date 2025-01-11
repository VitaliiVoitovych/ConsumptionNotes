using ConsumptionNotes.Desktop.Views.Adding;

namespace ConsumptionNotes.Desktop.Startup;

public static class ServiceRegistration
{
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        // Adding views
        return services
            .AddTransient<ElectricityAddingView>()
            .AddTransient<NaturalGasAddingView>();
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        return services
            .AddTransient<MainViewModel>()
            .AddTransient<ElectricityDashboardViewModel>()
            .AddTransient<NaturalGasDashboardViewModel>()
            // Adding view models
            .AddScoped<ElectricityAddingViewModel>()
            .AddScoped<NaturalGasAddingViewModel>();
    }
}