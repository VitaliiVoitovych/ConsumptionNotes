using ConsumptionNotes.Dal.Extensions;
using ConsumptionNotes.Mobile.Startup;
using ConsumptionNotes.Presentation.Charts;
using ConsumptionNotes.Presentation.Notes;
using Microsoft.Extensions.Logging;
using PanCardView;
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
                .UseCardsView()
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
                .AddObservableNotesService()
                .AddViewModels()
                .AddPages();
            
            return builder;
        }
    }
}
