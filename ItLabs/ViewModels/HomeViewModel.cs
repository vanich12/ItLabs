using ItLabs.Command;
using ItLabs.Services;
using ItLabs.Utilities;
using ItLabs.Views;
using System.Windows.Input;
using System.Windows.Navigation;
using Unity;

namespace ItLabs.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToRegisterCommand = new RelayCommand(NavigateToRegister);
        }

        private void NavigateToRegister()
        {
            _navigationService.NavigateTo<RegisterPage>();
        }

        public ICommand NavigateToRegisterCommand { get; }
    }
}
