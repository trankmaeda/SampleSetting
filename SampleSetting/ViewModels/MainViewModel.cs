
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace SampleSetting.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationServiceInstance)
        {
            _navigationService = navigationServiceInstance;
        }

        public void NavigateToItemSettingPage()
        {
            _navigationService.Navigate(PageTokens.ItemSettingPage, "test message");
        }
    }
}
