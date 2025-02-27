using ConsumptionNotes.Desktop.ViewModels;
using ConsumptionNotes.Presentation.ViewModels;

namespace ConsumptionNotes.Desktop.Startup;

public static class ServicesRegistration
{
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        return services
            .AddTransient<CalculatorViewModel>()
             // Adding views
            .AddTransient<ElectricityAddingView>()
            .AddTransient<NaturalGasAddingView>()
            // Editing views
            .AddTransient<ElectricityEditingView>()
            .AddTransient<NaturalGasEditingView>();
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        return services
            .AddTransient<CalculatorView>()
            .AddTransient<MainViewModel>()
            .AddTransient<ElectricityDashboardViewModel>()
            .AddTransient<NaturalGasDashboardViewModel>()
            // Adding view models
            .AddScoped<ElectricityAddingViewModel>()
            .AddScoped<NaturalGasAddingViewModel>()
            // Editing view models
            .AddTransient<ElectricityEditingViewModel>()
            .AddTransient<NaturalGasEditingViewModel>();
    }
}