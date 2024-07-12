using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ItLabs.Services
{
    public interface INavigationService
    {
        void NavigateTo<TPage>() where TPage : Page;
    }
}
