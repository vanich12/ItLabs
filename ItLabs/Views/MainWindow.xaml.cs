using ItLabs.Services;
using ItLabs.Utilities;
using ItLabs.ViewModels;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace ItLabs.Views
{
    public partial class MainWindow : Window
    {
        private readonly IUnityContainer _container;
        private readonly ViewModelLocator _viewModelLocator;

        public MainWindow()
        {
            InitializeComponent();
            this.MinWidth = 450;

            ViewModelLocator.Initialize(MainFrame); // Передаем MainFrame в ViewModelLocator
            _viewModelLocator = new ViewModelLocator();

            // Получаем экземпляр NavigationService из ViewModelLocator
            var navigationService = _viewModelLocator.NavigationService;
            var vm = _viewModelLocator.HomeViewModel;

            // Переходим на начальную страницу (здесь это HomePage)
            navigationService.NavigateTo<HomePage>();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
