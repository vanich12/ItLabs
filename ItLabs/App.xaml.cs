using ItLabs.Services;
using ItLabs.Utilities;
using ItLabs.ViewModels;
using ItLabs.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace ItLabs
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IUnityContainer _container;
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    _container = new UnityContainer();

        //    var frame = new Frame();
        //    var navigationService = new NavigationService(frame, _container);

        //    _container.RegisterInstance<INavigationService>(navigationService);
        //    _container.RegisterType<HomeViewModel>();
        //    _container.RegisterType<RegisterViewModel>();
        //    _container.RegisterType<RegisterPage>();

        //    var mainWindow = _container.Resolve<MainWindow>();
        //    mainWindow.Show();
        //}
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    // Инициализация ViewModelLocator
        //    var locator = new ViewModelLocator();

        //    // Создание MainWindow и установка DataContext
        //    var mainWindow = new MainWindow
        //    {
        //        DataContext = locator.HomeViewModel // Установка HomeViewModel как DataContext для MainWindow
        //    };

        //    mainWindow.Show();
        //}
    }
}
