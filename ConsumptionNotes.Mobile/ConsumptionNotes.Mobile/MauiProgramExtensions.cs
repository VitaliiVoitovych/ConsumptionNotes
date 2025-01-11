using ConsumptionNotes.Application.Services;
using ConsumptionNotes.Dal.Extensions;
using ConsumptionNotes.Mobile.Services.Files;
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

            builder.Services.AddChartServices();
            builder.Services.AddNotesServices();

            builder.Services.AddSingleton<FileSystemService>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<ElectricityDashboardViewModel>();
            builder.Services.AddTransient<NaturalGasDashboardViewModel>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ElectricityDashboardPage>();
            builder.Services.AddTransient<NaturalGasDashboardPage>();

            builder.Services.AddScoped<ElectricityAddingViewModel>();
            builder.Services.AddScoped<NaturalAddingGasViewModel>();

            builder.Services.AddScoped<ElectricityAddingPage>();
            builder.Services.AddScoped<NaturalAddingGasPage>();

            return builder;
        }
    }
}
