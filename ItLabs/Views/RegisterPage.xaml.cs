using ItLabs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItLabs.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private RegisterViewModel _viewModel;
        public RegisterPage()
        {
            InitializeComponent();
            _viewModel = new RegisterViewModel();
            DataContext = _viewModel;
        }

        private void OnPageSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width <= 700 && !e.HeightChanged)
            {
                PDFbar1.Visibility = Visibility.Collapsed;
                PDFbar2.Visibility = Visibility.Collapsed;
                MainStackPanel.Visibility = Visibility.Visible;
                MainStackPanel.Margin = new Thickness(20);
                Grid.SetColumn(MainStackPanel,2);
                Grid.SetColumnSpan(MainStackPanel, 3);

            }
            else
            {
                PDFbar1.Visibility = Visibility.Visible;
                PDFbar2.Visibility = Visibility.Visible;
                MainStackPanel.Visibility = Visibility.Visible;
                Grid.SetColumn(MainStackPanel, 3);
                Grid.SetColumnSpan(MainStackPanel, 1);
                MainStackPanel.Margin = new Thickness(20);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SendingFormCommand.Execute(null);
            if (_viewModel.IsRegistered)
            {
                NavigationService.Navigate(new Confirmation());
            }
           
        }

    }
}
