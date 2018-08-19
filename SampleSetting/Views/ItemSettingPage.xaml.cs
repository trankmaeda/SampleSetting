using System;
using System.Threading.Tasks;
using Prism.Commands;
using SampleSetting.Models;
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

            SelectPrefectureCommand = new DelegateCommand(() => SelectPrefecture());
        }

        public DelegateCommand SelectPrefectureCommand { get; private set; }
        private void SelectPrefecture(Prefecture prefecture)
        {

        }
    }
}
