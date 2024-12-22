using ConsumptionNotes.Mobile.ViewModels;

namespace ConsumptionNotes.Mobile.Pages;

public partial class AddNaturalGasPage : ContentPage
{
	public AddNaturalGasPage(AddNaturalGasViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}