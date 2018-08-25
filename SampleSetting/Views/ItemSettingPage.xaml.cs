using System;

using SampleSetting.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SampleSetting.Views
{
    public sealed partial class ItemSettingPage : Page
    {
        private ItemSettingViewModel ViewModel => DataContext as ItemSettingViewModel;

        public ItemSettingPage()
        {
            InitializeComponent();
        }
    }
}
