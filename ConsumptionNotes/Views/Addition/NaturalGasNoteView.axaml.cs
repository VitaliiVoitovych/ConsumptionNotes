using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Views.Addition;

public partial class NaturalGasNoteView : BaseNoteView
{
    public NaturalGasNoteView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasNoteViewModel>();
    }
    
    protected override ContentDialog CreateDialog()
    {
        var viewModel = DataContext as NaturalGasNoteViewModel;
        
        var dialog = base.CreateDialog();
        dialog.PrimaryButtonCommand = viewModel!.AddCommand;

        return dialog;
    }
}