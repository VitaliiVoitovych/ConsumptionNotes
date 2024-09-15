using System;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;

namespace ConsumptionNotes.Views
{
    public partial class MainWindow : AppWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            TitleBar.ExtendsContentIntoTitleBar = true;
            TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;
            
            ContentFrame.Navigate(typeof(HomeView));
        }

        private void NavigationView_OnSelectionChanged(object? sender, NavigationViewSelectionChangedEventArgs e)
        {
            var selectedView = ((NavigationViewItem)e.SelectedItem).Tag;
            var viewFullName = $"ConsumptionNotes.Views.{selectedView}";
            var viewType = Type.GetType(viewFullName);

            ContentFrame.Navigate(viewType);
        }
    }
}