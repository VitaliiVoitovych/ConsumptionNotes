using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Desktop.ViewModels.Editing;
using ConsumptionNotes.Desktop.Views.Adding;
using ConsumptionNotes.Desktop.Views.Editing;

namespace ConsumptionNotes.Desktop.Startup;

public static class ServicesRegistration
{
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        // Adding views
        return services
            .AddTransient<ElectricityAddingView>()
            .AddTransient<NaturalGasAddingView>()
            // Editing views
            .AddTransient<ElectricityEditingView>()
            .AddTransient<NaturalGasEditingView>();
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        return services
            .AddTransient<MainViewModel>()
            .AddTransient<ElectricityDashboardViewModel>()
            .AddTransient<NaturalGasDashboardViewModel>()
            // Adding view models
            .AddScoped<ElectricityAddingViewModel>()
            .AddScoped<NaturalGasAddingViewModel>()
            //
            .AddTransient<ElectricityEditingViewModel>()
            .AddTransient<NaturalGasEditingViewModel>();
    }
}