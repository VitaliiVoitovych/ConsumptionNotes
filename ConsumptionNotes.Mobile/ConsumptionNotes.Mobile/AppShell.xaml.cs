namespace ConsumptionNotes.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AddElectricityPage), typeof(AddElectricityPage));
        Routing.RegisterRoute(nameof(AddNaturalGasPage), typeof(AddNaturalGasPage));

        CurrentItem = PhoneTabs;
    }
}
