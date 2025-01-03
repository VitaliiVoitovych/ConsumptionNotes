using ConsumptionNotes.Mobile.ViewModels.Addition;

namespace ConsumptionNotes.Mobile.Pages;

public partial class AddNaturalGasPage : ContentPage
{
	public AddNaturalGasPage(AddNaturalGasViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}