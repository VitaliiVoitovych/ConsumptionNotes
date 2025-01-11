namespace ConsumptionNotes.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ElectricityAddingPage), typeof(ElectricityAddingPage));
        Routing.RegisterRoute(nameof(NaturalAddingGasPage), typeof(NaturalAddingGasPage));

        CurrentItem = PhoneTabs;
    }
}
