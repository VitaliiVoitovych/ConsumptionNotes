namespace ConsumptionNotes.Mobile.Pages.Adding;

public partial class AddNaturalGasPage : ContentPage
{
	public AddNaturalGasPage(AddNaturalGasViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}