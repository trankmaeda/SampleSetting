using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

using SampleSetting.Helpers;
using SampleSetting.Services;

using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Xaml;

namespace SampleSetting.ViewModels
{
    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    public class SettingsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private ElementTheme _elementTheme = ThemeSelectorService.Theme;

        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set { SetProperty(ref _elementTheme, value); }
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }

            set { SetProperty(ref _versionDescription, value); }
        }

        private ICommand _switchThemeCommand;

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new DelegateCommand<object>(
                        async (param) =>
                        {
                            ElementTheme = (ElementTheme)param;
                            await ThemeSelectorService.SetThemeAsync((ElementTheme)param);
                        });
                }

                return _switchThemeCommand;
            }
        }

        private string _serverIp;
        public string ServerIp
        {
            get => _serverIp;
            set
            {
                if (SetProperty(ref _serverIp, value))
                {
                    AccessCommand.RaiseCanExecuteChanged();
                }
            }
        }

        //TODO: Remove this if it's not needed to control button accessibility.
        private bool _accessInProgress;
        public bool AccessInProgress
        {
            get => _accessInProgress;
            set
            {
                if (SetProperty(ref _accessInProgress, value))
                {
                    AccessCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand AccessCommand { get; private set; }
        public Func<bool> CanTryAccess => () => !string.IsNullOrEmpty(ServerIp) && !AccessInProgress;

        public SettingsViewModel(INavigationService navigationServiceInstance)
        {
            _navigationService = navigationServiceInstance;
            AccessCommand = new DelegateCommand(async () => await AccessAsync(), CanTryAccess);
        }

        private async Task AccessAsync()
        {
            AccessInProgress = true;
            await Task.Delay(1000);
            AccessInProgress = false;

            ApplicationDataContainer container = ApplicationData.Current.LocalSettings;
            container.Values[nameof(ServerIp)] = ServerIp;
            _navigationService.Navigate(PageTokens.MainPage, null);
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            ApplicationDataContainer container = ApplicationData.Current.LocalSettings;
            var ip = container.Values[nameof(ServerIp)];
            if (ip != null)
            {
                ServerIp = ip.ToString();
                Debug.WriteLine($"Successed to get server ip[{ServerIp}] from cache.");
                AccessCommand.Execute();
            }

            VersionDescription = GetVersionDescription();
        }

        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
