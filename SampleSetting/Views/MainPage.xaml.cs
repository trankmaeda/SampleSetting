using System;

using SampleSetting.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SampleSetting.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
