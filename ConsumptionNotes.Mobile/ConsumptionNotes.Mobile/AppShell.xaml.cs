namespace ConsumptionNotes.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Adding pages
        Routing.RegisterRoute(nameof(ElectricityAddingPage), typeof(ElectricityAddingPage));
        Routing.RegisterRoute(nameof(NaturalGasAddingPage), typeof(NaturalGasAddingPage));
        // Editing pages
        Routing.RegisterRoute(nameof(ElectricityEditingPage), typeof(ElectricityEditingPage));
        Routing.RegisterRoute(nameof(NaturalGasEditingPage), typeof(NaturalGasEditingPage));
        
        CurrentItem = PhoneTabs;
    }
}
