using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Notes;
using ConsumptionNotes.Desktop.ViewModels;
using ConsumptionNotes.Desktop.ViewModels.Addition;
using ConsumptionNotes.Desktop.ViewModels.Dashboards;
using ConsumptionNotes.Desktop.Views.Addition;

namespace ConsumptionNotes.Desktop.Startup;

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