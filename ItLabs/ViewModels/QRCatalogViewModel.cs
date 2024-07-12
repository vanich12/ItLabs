using ItLabs.Command;
using ItLabs.Services;
using ItLabs.Utilities;
using ItLabs.Views;
using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace ItLabs.ViewModels
{
    public class QRCatalogViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private readonly DispatcherTimer _timer;

        public QRCatalogViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // Initialize the timer
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(20)
            };
            _timer.Tick += Timer_Tick;

            // Start the timer immediately
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            _navigationService.NavigateTo<HomePage>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
