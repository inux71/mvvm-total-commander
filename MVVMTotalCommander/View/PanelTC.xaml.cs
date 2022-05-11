using System.Windows.Controls;

namespace MVVMTotalCommander.View
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public sealed partial class PanelTC : UserControl
    {
        private readonly ViewModel.PanelTCViewModel panelTCViewModel;

        public PanelTC()
        {
            InitializeComponent();

            panelTCViewModel = new ViewModel.PanelTCViewModel();
            DataContext = panelTCViewModel;
        }
    }
}