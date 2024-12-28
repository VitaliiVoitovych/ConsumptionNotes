namespace ConsumptionNotes.Mobile;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    protected override void OnStart()
    {
        UserAppTheme = AppTheme.Dark;
        
        base.OnStart();
    }
}
