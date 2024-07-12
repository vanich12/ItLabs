using ItLabs.Services;
using System.Windows.Controls;
using Unity;

public class NavigationService : INavigationService
{
    private readonly Frame _frame;
    private readonly IUnityContainer _container;

    public NavigationService(Frame frame, IUnityContainer container)
    {
        _frame = frame;
        _container = container;
    }

    public void NavigateTo<TPage>() where TPage : Page
    {
        var page = _container.Resolve<TPage>();
        _frame.Navigate(page);
    }
}
