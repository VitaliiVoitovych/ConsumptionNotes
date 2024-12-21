using ConsumptionNotes.Mobile.Droid.Handlers;
using ConsumptionNotes.Mobile.Views;

namespace ConsumptionNotes.Mobile.Droid
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler<BottomSheet, BottomSheetHandler>();
                })
                .UseSharedMauiApp();

            return builder.Build();
        }
    }
}
