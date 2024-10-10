using ConsumptionNotes.Views.SplashScreen;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Media.Animation;
using FluentAvalonia.UI.Windowing;

namespace ConsumptionNotes.Views
{
    public partial class MainWindow : AppWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            SplashScreen = new ComplexSplashScreen();
            
            TitleBar.ExtendsContentIntoTitleBar = true;
            TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;
        }

        private void NavigationView_OnSelectionChanged(object? sender, NavigationViewSelectionChangedEventArgs e)
        {
            var selectedView = ((NavigationViewItem)e.SelectedItem).Tag;
            var viewFullName = $"ConsumptionNotes.Views.{selectedView}";
            var viewType = Type.GetType(viewFullName);

            
            ContentFrame.Navigate(viewType, null, new SuppressNavigationTransitionInfo());
        }
    }
}