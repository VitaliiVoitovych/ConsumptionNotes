using ConsumptionNotes.Presentation.ViewModels;

namespace ConsumptionNotes.Mobile.Pages;

public partial class CalculatorPage : ContentPage
{
    public CalculatorPage(CalculatorViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        BackButton.Command = new GoToCommand("..", true).Command;
    }
}