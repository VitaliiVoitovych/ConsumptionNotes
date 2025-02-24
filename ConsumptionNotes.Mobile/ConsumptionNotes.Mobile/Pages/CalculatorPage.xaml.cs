using ConsumptionNotes.Mobile.ViewModels;

namespace ConsumptionNotes.Mobile.Pages;

public partial class CalculatorPage : ContentPage
{
    public CalculatorPage(CalculatorViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}