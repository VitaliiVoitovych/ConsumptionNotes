namespace ConsumptionNotes.Mobile.Pages.Adding;

public partial class NaturalGasAddingPage : ContentPage
{
	public NaturalGasAddingPage(NaturalGasAddingViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}