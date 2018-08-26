using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SampleSetting.Models;

namespace SampleSetting.ViewModels
{
    public class ItemSettingViewModel : ViewModelBase
    {
        public ObservableCollection<Prefecture> Prefectures { get; private set; }

        public ItemSettingViewModel()
        {
            InitializeDummyData();
        }

        private DelegateCommand<Prefecture> _selectPrefectureCommand;
        public DelegateCommand<Prefecture> SelectPrefectureCommand
        {
            get
            {
                if (_selectPrefectureCommand == null)
                {
                    _selectPrefectureCommand = new DelegateCommand<Prefecture>(
                        (prefecture) =>
                        {
                            Debug.WriteLine($"ID[{prefecture.ID}] Name[{prefecture.Name}]");
                        });
                }

                return _selectPrefectureCommand;
            }
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            Debug.WriteLine($"Received parameter: {e.Parameter}");
        }

        private void InitializeDummyData()
        {
            Prefectures = new ObservableCollection<Prefecture>
            {
                new Prefecture
                {
                    ID = 1,
                    Name = "Aomori",
                    StartDate = new DateTime(1945, 8, 15),
                    Cities = new List<City>
                    {
                        new City
                        {
                            ID = 11,
                            Name = "Aomori",
                            Mayor = "AomoriJin",
                        },
                        new City
                        {
                            ID = 12,
                            Name = "Hiromae",
                            Mayor = "Hirosi",
                        },
                        new City
                        {
                            ID = 13,
                            Name = "Yato",
                            Mayor = "Yassan",
                        },
                        new City
                        {
                            ID = 14,
                            Name = "Kuroisi",
                            Mayor = "Kuroi",
                        },
                        new City
                        {
                            ID = 15,
                            Name = "Goshogawara",
                            Mayor = "Gomi",
                        },
                    },
                },
                new Prefecture
                {
                    ID = 2,
                    Name = "Akita",
                    StartDate = new DateTime(1977, 7, 10),
                    Cities = new List<City>
                    {
                        new City
                        {
                            ID = 21,
                            Name = "Akita",
                            Mayor = "Akiyama",
                        },
                        new City
                        {
                            ID = 22,
                            Name = "Ojika",
                            Mayor = "Oji",
                        },
                        new City
                        {
                            ID = 23,
                            Name = "Gojou",
                            Mayor = "Gojin",
                        },
                    },
                },
                new Prefecture
                {
                    ID = 3,
                    Name = "Iwate",
                    StartDate = DateTime.Now,
                    Cities = new List<City>
                    {
                        new City
                        {
                            ID = 31,
                            Name = "Morioka",
                            Mayor = "Morita",
                        },
                        new City
                        {
                            ID = 32,
                            Name = "Hatimanndaira",
                            Mayor = "Yassan",
                        },
                        new City
                        {
                            ID = 33,
                            Name = "Takizawa",
                            Mayor = "Tanigawa",
                        },
                        new City
                        {
                            ID = 34,
                            Name = "Iwate",
                            Mayor = "Iwama",
                        },
                    },
                },
            };
        }
    }
}
