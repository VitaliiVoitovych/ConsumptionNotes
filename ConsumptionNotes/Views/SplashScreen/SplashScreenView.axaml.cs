using Avalonia.Threading;

namespace ConsumptionNotes.Views.SplashScreen;

public partial class SplashScreenView : UserControl
{
    private const string SplashScreenText = "Підготовка програми...";
    
    public async Task InitApp()
    {
        var start = DateTime.Now.Ticks;
        var time = start;
        var progressValue = 0;
        
        Dispatcher.UIThread.Post(() => LoadingText.Text = SplashScreenText);
        
        while ((time - start) < TimeSpan.TicksPerSecond)
        {
            progressValue++;
            Dispatcher.UIThread.Post(() => LoadProgressBar.Value = progressValue);
            await Task.Delay(100);
            time = DateTime.Now.Ticks;
        }
        
        start = time;
        var limit = TimeSpan.TicksPerSecond * 2.5;
        while ((time - start) < limit)
        {
            progressValue += 1;
            Dispatcher.UIThread.Post(() => LoadProgressBar.Value = progressValue);
            await Task.Delay(150);
            time = DateTime.Now.Ticks;
        }

        while (progressValue < 100)
        {
            progressValue += 1;
            Dispatcher.UIThread.Post(() => LoadProgressBar.Value = progressValue);
            await Task.Delay(10);
        }
    }
    
    public SplashScreenView()
    {
        InitializeComponent();
    }
}