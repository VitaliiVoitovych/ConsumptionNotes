using ConsumptionNotes.Desktop.ViewModels.Addition;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Desktop.Views.Addition;

public partial class ElectricityNoteView : BaseNoteView
{
    public ElectricityNoteView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityNoteViewModel>();
    }

    protected override ContentDialog CreateDialog()
    {
        var viewModel = DataContext as ElectricityNoteViewModel;
        
        var dialog = base.CreateDialog();
        dialog.PrimaryButtonCommand = viewModel!.AddCommand;

        return dialog;
    }
}