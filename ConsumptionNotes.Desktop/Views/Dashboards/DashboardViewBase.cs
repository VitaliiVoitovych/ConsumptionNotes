using Avalonia.Controls.Primitives;

namespace ConsumptionNotes.Desktop.Views.Dashboards;

public abstract class DashboardViewBase : UserControl
{
    private ScrollBar? _dataGridVerticalScrollBar;
    
    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        base.OnSizeChanged(e);

        var newHeight = e.NewSize.Height;
        var height = newHeight > 630 ? newHeight / 2 - 20 : Bounds.Height - 20;

        UpdateChartWidgetsHeight(height);
    }

    protected abstract void UpdateChartWidgetsHeight(double height);

    protected void GetVerticalScrollBar(object? sender, TemplateAppliedEventArgs e)
    {
        _dataGridVerticalScrollBar = e.NameScope.Find<ScrollBar>("PART_VerticalScrollbar");
    }

    protected void UpdateDataGridVerticalScrollBarStyle(object? sender, EventArgs e)
    {
        if (sender is not DataGrid dataGrid) return;
        
        if (_dataGridVerticalScrollBar is not null && _dataGridVerticalScrollBar.IsVisible)
            dataGrid.Classes.Add("VerticalScrollBarVisible");
        else
            dataGrid.Classes.Remove("VerticalScrollBarVisible");
    }
}