using ItLabs.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ItLabs.Views
{
    public partial class Confirmation : Page
    {
        private ConfirmationViewModel _viewModel;

        public Confirmation()
        {
            InitializeComponent();
            _viewModel = new ConfirmationViewModel();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ConfirmCommand.Execute(null);
            if (_viewModel.IsConfirmed)
            {
                NavigationService.Navigate(new QRCatalogPage());
            }
        }
    }
}
