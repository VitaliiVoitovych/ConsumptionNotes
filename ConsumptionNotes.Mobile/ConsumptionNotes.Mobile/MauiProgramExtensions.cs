using ConsumptionNotes.Application.Services;
using ConsumptionNotes.Dal.Extensions;
using ConsumptionNotes.Mobile.Services.Files;
using ConsumptionNotes.Mobile.Startup;
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

            builder.Services.AddSingleton<FileSystemService>();
            
            builder.Services
                .AddDatabase()
                .AddRepositories()
                .AddChartServices()
                .AddNotesServices()
                .AddViewModels()
                .AddPages();
            
            return builder;
        }
    }
}
