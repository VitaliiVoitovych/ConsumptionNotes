using ConsumptionNotes.Dal.Extensions;
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
            builder.Services.AddConsumptionDbContext(connectionString);
            
            return builder;
        }
    }
}
