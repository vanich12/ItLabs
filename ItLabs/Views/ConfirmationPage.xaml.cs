using ItLabs.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ItLabs.Views
{
    public partial class ConfirmationPage : Page
    {

        public ConfirmationPage()
        {
            InitializeComponent();
        }

        //что то на подобии адаптива
        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width <= 700 && !e.HeightChanged)
            {
                PDFbar1.Visibility = Visibility.Collapsed;
                PDFbar2.Visibility = Visibility.Collapsed;
                MainStackPanel.Visibility = Visibility.Visible;
                MainStackPanel.Margin = new Thickness(20);
                Grid.SetColumnSpan(MainStackPanel, 3);
                Grid.SetColumn(MainStackPanel, 0);

            }
            else
            {
                PDFbar1.Visibility = Visibility.Visible;
                PDFbar2.Visibility = Visibility.Visible;
                MainStackPanel.Visibility = Visibility.Visible;
                Grid.SetColumnSpan(MainStackPanel, 1);
                MainStackPanel.Margin = new Thickness(20);
            }
        }
    }
}
