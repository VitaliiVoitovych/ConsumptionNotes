namespace ConsumptionNotes.Mobile.Pages.Adding;

public partial class NaturalAddingGasPage : ContentPage
{
	public NaturalAddingGasPage(NaturalAddingGasViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}