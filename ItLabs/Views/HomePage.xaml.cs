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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        //private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //   NavigationService.Navigate(new RegisterPage());
        //}

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width <= 700 && !e.HeightChanged)
            {
                MainViewBox.Stretch = Stretch.Uniform;
                Grid.SetColumn(MainStackPanel, 1);
                Grid.SetColumnSpan(MainStackPanel, 3);
                MainStackPanel.Margin = new Thickness(20);
            }
            else
            {
                MainViewBox.Stretch = Stretch.Fill;
                Grid.SetColumn(MainStackPanel, 2);
                Grid.SetColumnSpan(MainStackPanel, 1);
                MainStackPanel.Margin = new Thickness(0);
            }
        }

        //private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    NavigationService.Navigate(new RegisterPage());
        //}
    }
}
