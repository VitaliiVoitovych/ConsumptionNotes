using ConsumptionNotes.Mobile.ViewModels.Editing;

namespace ConsumptionNotes.Mobile.Pages.Editing;

public partial class NaturalGasEditingPage : ContentPage
{
    public NaturalGasEditingPage(NaturalGasEditingViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}