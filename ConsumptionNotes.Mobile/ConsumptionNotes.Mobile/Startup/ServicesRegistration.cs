using ConsumptionNotes.Presentation.ViewModels;

namespace ConsumptionNotes.Mobile.Startup;

public static class ServicesRegistration
{
    public static IServiceCollection AddPages(this IServiceCollection services)
    {
        return services
            .AddTransient<MainPage>()
            // Dashboard pages
            .AddTransient<ElectricityDashboardPage>()
            .AddTransient<NaturalGasDashboardPage>()
            // Adding pages
            .AddScoped<ElectricityAddingPage>()
            .AddScoped<NaturalGasAddingPage>()
            // Editing pages
            .AddTransient<ElectricityEditingPage>()
            .AddTransient<NaturalGasEditingPage>();
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        return services
            .AddTransient<MainViewModel>()
            // Dashboard view models
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