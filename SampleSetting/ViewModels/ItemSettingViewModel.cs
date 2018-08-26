using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SampleSetting.Models;
using static SampleSetting.Models.School;

namespace SampleSetting.ViewModels
{
    public class ItemSettingViewModel : ViewModelBase
    {
        public ObservableCollection<Prefecture> Prefectures { get; private set; }
        public ObservableCollection<City> Cities { get; } = new ObservableCollection<City>();
        public ObservableCollection<SchoolDistrict> SchoolDistricts { get; } = new ObservableCollection<SchoolDistrict>();
        //TODO: Move this to model class in real use.
        public List<SchoolDistrict> AllSchoolDistricts { get; private set; }

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
                            Debug.WriteLine($"Prefecture: ID[{prefecture.ID}] Name[{prefecture.Name}]");
                            Cities.Clear();
                            foreach (var city in prefecture.Cities)
                            {
                                Cities.Add(city);
                            }
                            var schoolDistrictID = prefecture.SchoolDistrictId;
                            SchoolDistricts.Clear();
                            foreach (var schoolDistrict in AllSchoolDistricts)
                            {
                                if (schoolDistrict.ID == prefecture.SchoolDistrictId)
                                {
                                    SchoolDistricts.Add(schoolDistrict);
                                }
                            }
                        });
                }

                return _selectPrefectureCommand;
            }
        }

        private DelegateCommand<City> _selectCityCommand;
        public DelegateCommand<City> SelectCityCommand
        {
            get
            {
                if (_selectCityCommand == null)
                {
                    _selectCityCommand = new DelegateCommand<City>(
                        (city) =>
                        {
                            if (city == null) { return; }
                            Debug.WriteLine($"City: ID[{city.ID}] Name[{city.Name}] Mayor[{city.Mayor}]");
                        });
                }

                return _selectCityCommand;
            }
        }

        private DelegateCommand<SchoolDistrict> _selectSchoolDistrictCommand;
        public DelegateCommand<SchoolDistrict> SelectSchoolDistrictCommand
        {
            get
            {
                if (_selectSchoolDistrictCommand == null)
                {
                    _selectSchoolDistrictCommand = new DelegateCommand<SchoolDistrict>(
                        (schoolDistrict) =>
                        {
                            if (schoolDistrict == null) { return; }
                            Debug.WriteLine($"SchoolDistrict: ID[{schoolDistrict.ID}] Name[{schoolDistrict.Name}]");
                        });
                }

                return _selectSchoolDistrictCommand;
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
                    SchoolDistrictId = 1,
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
                    SchoolDistrictId = 2,
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

            AllSchoolDistricts = new List<SchoolDistrict>{
                new SchoolDistrict
                {
                    ID = 1,
                    Name = "学区1",
                    Schools = new List<School>
                    {
                        new School
                        {
                            Name = "第1高校",
                            Size = BuildingSize.Default,
                        },
                        new School
                        {
                            Name = "大高校",
                            Size = BuildingSize.Big,
                        },
                        new School
                        {
                            Name = "小高校",
                            Size = BuildingSize.Small,
                        },
                        new School
                        {
                            Name = "通常高校",
                        },
                    }
                },
                new SchoolDistrict
                {
                    ID = 2,
                    Name = "学区2",
                    Schools = new List<School>
                    {
                        new School
                        {
                            Name = "第2高校",
                            Size = BuildingSize.Default,
                        },
                        new School
                        {
                            Name = "第22高校",
                            Size = BuildingSize.Default
                        },
                        new School
                        {
                            Name = "巨大高校",
                            Size = BuildingSize.Big,
                        },
                        new School
                        {
                            Name = "巨大高校2",
                            Size = BuildingSize.Big,
                        },
                        new School
                        {
                            Name = "巨大高校3",
                            Size = BuildingSize.Big,
                        },
                    }
                }
            };
            foreach (var schoolDistrict in AllSchoolDistricts)
            {
                SchoolDistricts.Add(schoolDistrict);
            }
        }
    }
}
