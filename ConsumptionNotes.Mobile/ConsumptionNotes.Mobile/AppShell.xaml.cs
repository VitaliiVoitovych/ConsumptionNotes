namespace ConsumptionNotes.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ElectricityAddingPage), typeof(ElectricityAddingPage));
        Routing.RegisterRoute(nameof(NaturalGasAddingPage), typeof(NaturalGasAddingPage));

        CurrentItem = PhoneTabs;
    }
}
