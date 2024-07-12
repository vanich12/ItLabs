using ItLabs.Services;
using ItLabs.ViewModels;
using ItLabs.Views;
using System.Windows.Controls;
using Unity;

namespace ItLabs.Utilities
{
    public class ViewModelLocator
    {
        private static IUnityContainer _container;
        private static Frame _frame;

        static ViewModelLocator()
        {
            _container = new UnityContainer();
        }

        public static void Initialize(Frame frame)
        {
            _frame = frame;
            var navigationService = new NavigationService(_frame, _container); // Создаем экземпляр NavigationService

            _container.RegisterInstance<INavigationService>(navigationService); // Регистрируем NavigationService как singleton

            // Регистрируем все ViewModel и страницы, которые будем использовать
            _container.RegisterType<HomeViewModel>();
            _container.RegisterType<RegisterViewModel>();
            _container.RegisterType<RegisterPage>();
            _container.RegisterType<ConfirmationViewModel>();
            _container.RegisterType<ConfirmationPage>();
            _container.RegisterType<QRCatalogViewModel>();
            _container.RegisterType<QRCatalogPage>();
        }

        // Свойства для получения экземпляров ViewModel
        public HomeViewModel HomeViewModel => _container.Resolve<HomeViewModel>();
        public RegisterViewModel RegisterViewModel => _container.Resolve<RegisterViewModel>();
        public ConfirmationViewModel ConfirmationViewModel => _container.Resolve<ConfirmationViewModel>();
        public QRCatalogViewModel QRCatalogViewModel => _container.Resolve<QRCatalogViewModel>();   

        // Доступ к NavigationService для навигации между страницами
        public INavigationService NavigationService => _container.Resolve<INavigationService>();
    }
}
