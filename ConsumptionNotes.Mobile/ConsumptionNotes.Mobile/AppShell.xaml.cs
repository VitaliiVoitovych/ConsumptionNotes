namespace ConsumptionNotes.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        RegisterRoutes();
        
        CurrentItem = PhoneTabs;
    }

    private static void RegisterRoutes()
    {
        // Adding pages
        Routing.RegisterRoute(nameof(ElectricityAddingPage), typeof(ElectricityAddingPage));
        Routing.RegisterRoute(nameof(NaturalGasAddingPage), typeof(NaturalGasAddingPage));
        // Editing pages
        Routing.RegisterRoute(nameof(ElectricityEditingPage), typeof(ElectricityEditingPage));
        Routing.RegisterRoute(nameof(NaturalGasEditingPage), typeof(NaturalGasEditingPage));
                
        Routing.RegisterRoute(nameof(CalculatorPage), typeof(CalculatorPage));
    }
}
