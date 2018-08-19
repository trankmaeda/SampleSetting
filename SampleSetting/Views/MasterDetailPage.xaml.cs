﻿using System;

using SampleSetting.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SampleSetting.Views
{
    public sealed partial class MasterDetailPage : Page
    {
        private MasterDetailViewModel ViewModel => DataContext as MasterDetailViewModel;

        public MasterDetailPage()
        {
            InitializeComponent();
        }
    }
}
