using ConsumptionNotes.Mobile.ViewModels;

namespace ConsumptionNotes.Mobile.Pages;

public partial class NaturalGasDashboardPage : ContentPage
{
    public NaturalGasDashboardPage(NaturalGasDashboardViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}