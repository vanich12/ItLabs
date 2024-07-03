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
using System.Windows.Threading;

namespace ItLabs.Views
{
    /// <summary>
    /// Логика взаимодействия для QRCatalogPage.xaml
    /// </summary>
    public partial class QRCatalogPage : Page
    {
        private DispatcherTimer _timer;
        public QRCatalogPage()
        {
            InitializeComponent();
            StartTime();
        }

        private void StartTime()
        { 
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(20);
            // подписка на специальное событие, которое срабатывает по завершению интервала
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            NavigationService.Navigate(new HomePage());    
        }
    }
}
