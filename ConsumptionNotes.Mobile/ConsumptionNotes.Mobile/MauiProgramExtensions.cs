using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Notes;
using ConsumptionNotes.Dal.Extensions;
using ConsumptionNotes.Mobile.Pages;
using ConsumptionNotes.Mobile.ViewModels;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace ConsumptionNotes.Mobile
{
    public static class MauiProgramExtensions
    {
        public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
        {
            builder
                .UseSkiaSharp()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            const string filename = "consumption.db";
            var connectionString = Path.Combine(FileSystem.Current.AppDataDirectory, filename);
            builder.Services.AddConsumptionDbContext($"Data Source={connectionString}");

            builder.Services.AddRepositories();

            builder.Services.AddSingleton<ElectricityChartService>();
            builder.Services.AddSingleton<NaturalGasChartService>();

            builder.Services.AddSingleton<ElectricityNotesService>();
            builder.Services.AddSingleton<NaturalGasNotesService>();
            
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<ElectricityDashboardViewModel>();
            builder.Services.AddTransient<NaturalGasDashboardViewModel>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ElectricityDashboardPage>();
            builder.Services.AddTransient<NaturalGasDashboardPage>();
            
            return builder;
        }
    }
}
