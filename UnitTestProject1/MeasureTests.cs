using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using Test.Model;
using System.IO;
using Test.ViewModel.Commands;
using Test.ViewModel;

namespace UnitTestProject1
{
    [TestClass]
    public class MeasureTests
    {
        /*
         * Тестирует метод:
         * 
           public override void Execute(object parameter)
           {
                if (_viewModel.SelectedClient.City == "Москва")
                {
                    _viewModel.SelectedClient.MeasureDate = _viewModel.CalendarDate.ToShortDateString();
                    _viewModel.SelectedClient.MeasureTime = _viewModel.SelectedInterval.IntervalValue;
                }
                else
                    _viewModel.SelectedClient.MeasureDate = _viewModel.CalendarDate.ToShortDateString();

                var newMeasure = new Date()
                {
                    ClientID = _viewModel.SelectedClient.Id,
                    CityName = _viewModel.SelectedClient.City,
                    MeasureDate = _viewModel.CalendarDate.ToShortDateString(),
                    MeasureDayOfWeek = _viewModel.CalendarDate.DayOfWeek,
                    Interval = _viewModel.SelectedInterval.IntervalValue
                };

                _date.AddNewMeasureToCollection(_viewModel.MeasureDates, newMeasure); // Планируется новый замер                         

                if (_date.GetMeasureRemaining(default, default, _viewModel.MeasureDates, _viewModel.Cities, _viewModel.Intervals, _viewModel.SelectedClient, _viewModel.SelectedInterval, _viewModel.CalendarDate) >= 0)
                {
                    if (_viewModel.SelectedClient.City == "Москва")
                        MessageBox.Show($"Slots left for {_viewModel.SelectedClient.City} on {_viewModel.CalendarDate.ToShortDateString()} - {_viewModel.SelectedInterval.IntervalValue} : {_date.GetMeasureRemaining(default, default, _viewModel.MeasureDates, _viewModel.Cities, _viewModel.Intervals, _viewModel.SelectedClient, _viewModel.SelectedInterval, _viewModel.CalendarDate)}", "Succeed!", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show($"Slots left for {_viewModel.SelectedClient.City} on {_viewModel.CalendarDate.ToShortDateString()}: {_date.GetMeasureRemaining(default, default, _viewModel.MeasureDates, _viewModel.Cities, _viewModel.Intervals, _viewModel.SelectedClient, _viewModel.SelectedInterval, _viewModel.CalendarDate)}", "Succeed!", MessageBoxButton.OK, MessageBoxImage.Information);

                    _date.SaveMeasuresData(_viewModel.MeasureDates, _viewModel.datesPath);
                    _client.SaveClientsData(_viewModel.Clients, _viewModel.clientsPath);
                    _client.LoadClientsData(_viewModel.Clients, _viewModel.clientsPath);
                    _viewModel.UpdateClientsData();
                    _viewModel.OnPropertyChanged("Clients");
                }
                else
                {
                    if (_viewModel.SelectedClient.City == "Москва")
                        MessageBox.Show($"No slots for {_viewModel.SelectedClient.City} on {_viewModel.CalendarDate.ToShortDateString()} - {_viewModel.SelectedInterval.IntervalValue} left", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show($"No slots for {_viewModel.SelectedClient.City} on {_viewModel.CalendarDate.ToShortDateString()} left", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

                    _viewModel.MeasureDates.Remove(newMeasure);
                    _viewModel.SelectedClient.MeasureDate = string.Empty;
                    return;
                }
            }
         */

        [TestMethod]
        public void ShouldMakeAMeasure()
        {
            // Входящие данные
            ObservableCollection<Client> Clients = new ObservableCollection<Client>()
            {
                new Client { Id = "AAA001", Name = "Name01", City = "Москва", Address = "Adress01", PhoneNumber = "PhoneNumber01", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA002", Name = "Name02", City = "Саратов", Address = "Adress02", PhoneNumber = "PhoneNumber02", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA003", Name = "Name03", City = "Москва", Address = "Adress03", PhoneNumber = "PhoneNumber03", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA004", Name = "Name04", City = "Саратов", Address = "Adress04", PhoneNumber = "PhoneNumber04", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA005", Name = "Name05", City = "Саратов", Address = "Adress05", PhoneNumber = "PhoneNumber05", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA006", Name = "Name06", City = "Москва", Address = "Adress06", PhoneNumber = "PhoneNumber06", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA007", Name = "Name07", City = "Саратов", Address = "Adress07", PhoneNumber = "PhoneNumber07", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA008", Name = "Name08", City = "Москва", Address = "Adress08", PhoneNumber = "PhoneNumber08", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA009", Name = "Name09", City = "Саратов", Address = "Adress09", PhoneNumber = "PhoneNumber09", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA010", Name = "Name10", City = "Саратов", Address = "Adress10", PhoneNumber = "PhoneNumber10", MeasureDate = "", MeasureTime = null }
            };
            ObservableCollection<City> Cities = new ObservableCollection<City>()
            {
                new City
                {
                    СityName = "Саратов",
                           Week = new ObservableCollection<Day> {
                                                                    new Day { DayOfWeek = DayOfWeek.Monday, MeasurmentDefault = 8},
                                                                    new Day { DayOfWeek = DayOfWeek.Tuesday, MeasurmentDefault = 7},
                                                                    new Day { DayOfWeek = DayOfWeek.Wednesday, MeasurmentDefault = 7},
                                                                    new Day { DayOfWeek = DayOfWeek.Thursday, MeasurmentDefault = 6},
                                                                    new Day { DayOfWeek = DayOfWeek.Friday, MeasurmentDefault = 6},
                                                                    new Day { DayOfWeek = DayOfWeek.Saturday, MeasurmentDefault = 3},
                                                                    new Day { DayOfWeek = DayOfWeek.Sunday, MeasurmentDefault = 0}
                                                                }
                },
                new City
                {
                    СityName = "Москва",
                           Week = new ObservableCollection<Day> {
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Monday,
                                                                                MeasurmentDefault = 18,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 3 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Tuesday,
                                                                                MeasurmentDefault = 18,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 3 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Wednesday,
                                                                                MeasurmentDefault = 16,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 2 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Thursday,
                                                                                MeasurmentDefault = 12,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 2 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Friday,
                                                                                MeasurmentDefault = 12,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 2 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Saturday,
                                                                                MeasurmentDefault = 6,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 0 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 0 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Sunday,
                                                                                MeasurmentDefault = 0,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 0 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 0 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 0 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 0 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 0 },
                                                                                                                                }
                                                                            },

                                                            }
                }
            };
            ObservableCollection<Interval> Intervals = new ObservableCollection<Interval>();
            ObservableCollection<Date> MeasureDates = new ObservableCollection<Date>();

            Interval interval = new Interval();
            Interval SelectedInterval;

            Client SelectedClient = Clients[1];
            Client _client = new Client();
            Date _date = new Date();

            DateTime CalendarDate = new DateTime(2021, 11, 10);
            string clientsPath = $"{Environment.CurrentDirectory}\\/Clients.json";
            string citiesPath = $"{Environment.CurrentDirectory}\\/Cities.json";
            string datesPath = $"{Environment.CurrentDirectory}\\/MeasureDates.json";
            string CityName = "Москва";

            Intervals = interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);
            SelectedInterval = Intervals[1];

            ViewModel viewModel = new ViewModel(1)
            {
                SelectedClient = SelectedClient,
                CalendarDate = CalendarDate,
                SelectedInterval = SelectedInterval,
                MeasureDates = MeasureDates,
                Cities = Cities,
                Intervals = Intervals,
                Clients = Clients,
                clientsPath = clientsPath,
                citiesPath = citiesPath,
                datesPath = datesPath,
            };

            NewMeasureCommand newMeasureCommand = new NewMeasureCommand(viewModel, _client, _date);

            // Ожидаемый результат
            var expected = _date.GetMeasureRemaining(default, default, MeasureDates, Cities, Intervals, SelectedClient.City, SelectedInterval, CalendarDate) - 1;

            // Результат
            newMeasureCommand.Execute(viewModel);
            MeasureDates = _date.LoadMeasureDatesData(MeasureDates, datesPath);

            var actual = _date.GetMeasureRemaining(default, default, MeasureDates, Cities, Intervals, SelectedClient.City, SelectedInterval, CalendarDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldMakeAllMeasuresForADay()
        {
            // Входящие данные
            ObservableCollection<Client> Clients = new ObservableCollection<Client>()
            {
                new Client { Id = "AAA001", Name = "Name01", City = "Москва", Address = "Adress01", PhoneNumber = "PhoneNumber01", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA002", Name = "Name02", City = "Саратов", Address = "Adress02", PhoneNumber = "PhoneNumber02", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA003", Name = "Name03", City = "Москва", Address = "Adress03", PhoneNumber = "PhoneNumber03", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA004", Name = "Name04", City = "Саратов", Address = "Adress04", PhoneNumber = "PhoneNumber04", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA005", Name = "Name05", City = "Саратов", Address = "Adress05", PhoneNumber = "PhoneNumber05", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA006", Name = "Name06", City = "Москва", Address = "Adress06", PhoneNumber = "PhoneNumber06", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA007", Name = "Name07", City = "Саратов", Address = "Adress07", PhoneNumber = "PhoneNumber07", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA008", Name = "Name08", City = "Москва", Address = "Adress08", PhoneNumber = "PhoneNumber08", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA009", Name = "Name09", City = "Саратов", Address = "Adress09", PhoneNumber = "PhoneNumber09", MeasureDate = "", MeasureTime = null },
                new Client { Id = "AAA010", Name = "Name10", City = "Саратов", Address = "Adress10", PhoneNumber = "PhoneNumber10", MeasureDate = "", MeasureTime = null }
            };
            ObservableCollection<City> Cities = new ObservableCollection<City>()
            {
                new City
                {
                    СityName = "Саратов",
                           Week = new ObservableCollection<Day> {
                                                                    new Day { DayOfWeek = DayOfWeek.Monday, MeasurmentDefault = 8},
                                                                    new Day { DayOfWeek = DayOfWeek.Tuesday, MeasurmentDefault = 7},
                                                                    new Day { DayOfWeek = DayOfWeek.Wednesday, MeasurmentDefault = 7},
                                                                    new Day { DayOfWeek = DayOfWeek.Thursday, MeasurmentDefault = 6},
                                                                    new Day { DayOfWeek = DayOfWeek.Friday, MeasurmentDefault = 6},
                                                                    new Day { DayOfWeek = DayOfWeek.Saturday, MeasurmentDefault = 3},
                                                                    new Day { DayOfWeek = DayOfWeek.Sunday, MeasurmentDefault = 0}
                                                                }
                },
                new City
                {
                    СityName = "Москва",
                           Week = new ObservableCollection<Day> {
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Monday,
                                                                                MeasurmentDefault = 18,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 3 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Tuesday,
                                                                                MeasurmentDefault = 18,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 3 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Wednesday,
                                                                                MeasurmentDefault = 16,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 4 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 2 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Thursday,
                                                                                MeasurmentDefault = 12,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 2 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Friday,
                                                                                MeasurmentDefault = 12,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 3 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 2 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Saturday,
                                                                                MeasurmentDefault = 6,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 2 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 0 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 0 },
                                                                                                                                }
                                                                            },
                                                                    new Day {
                                                                                DayOfWeek = DayOfWeek.Sunday,
                                                                                MeasurmentDefault = 0,
                                                                                Intervals = new ObservableCollection<Interval> {
                                                                                                                                    new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 0 },
                                                                                                                                    new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 0 },
                                                                                                                                    new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 0 },
                                                                                                                                    new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 0 },
                                                                                                                                    new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 0 },
                                                                                                                                }
                                                                            },

                                                            }
                }
            };
            ObservableCollection<Interval> Intervals = new ObservableCollection<Interval>();
            ObservableCollection<Date> MeasureDates = new ObservableCollection<Date>();

            Interval interval = new Interval();
            Interval SelectedInterval;

            Client SelectedClient = Clients.First();
            Client _client = new Client();
            Date _date = new Date();

            DateTime CalendarDate = new DateTime(2021, 11, 11);                     // ДАТУ ЗАМЕРОВ МЕНЯТЬ ТУТ
            string clientsPath = $"{Environment.CurrentDirectory}\\/Clients.json";
            string citiesPath = $"{Environment.CurrentDirectory}\\/Cities.json";
            string datesPath = $"{Environment.CurrentDirectory}\\/MeasureDates.json";
            string CityName = "Москва";

            Intervals = interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);
            SelectedInterval = Intervals[1];

            ViewModel viewModel = new ViewModel(1);
            NewMeasureCommand newMeasureCommand = new NewMeasureCommand(viewModel, _client, _date);

            // Ожидаемый результат
            var expectedSaratov = 0;
            var expectedMoscow = 0;

            // Результат

            for (int i = 0; i < Clients.Count; i++)
            {
                SelectedClient = Clients[i];

                viewModel.SelectedClient = SelectedClient;
                viewModel.SelectedInterval = SelectedInterval;
                viewModel.CalendarDate = CalendarDate;
                viewModel.MeasureDates = MeasureDates;
                viewModel.Cities = Cities;
                viewModel.Clients = Clients;
                viewModel.Intervals = Intervals;
                viewModel.clientsPath = clientsPath;
                viewModel.citiesPath = citiesPath;
                viewModel.datesPath = datesPath;

                newMeasureCommand.Execute(null);
            }

            MeasureDates = _date.LoadMeasureDatesData(MeasureDates, datesPath);

            var actualSaratov = _date.GetMeasureRemaining(default, default, MeasureDates, Cities, Intervals, "Саратов", SelectedInterval, CalendarDate);
            var actualMoscow = _date.GetMeasureRemaining(default, default, MeasureDates, Cities, Intervals, "Москва", SelectedInterval, CalendarDate);

            Assert.AreEqual(expectedSaratov, actualSaratov);
            Assert.AreEqual(expectedMoscow, actualMoscow);
        }


        /*
         * Тестирует метод:
         * 
           public RemoveMeasureDateCommand(ViewModel viewModel, Client client, Date date) : base(viewModel, client, date)
           {

           }

           public override bool CanExecute(object parameter)
           {
                if (_viewModel.SelectedClient == null || _viewModel.SelectedClient.MeasureDate == string.Empty)
                    return false;
                else
                    return true;
           }

           public override void Execute(object parameter)
           {
                _viewModel.SelectedClient.MeasureDate = string.Empty;
                _viewModel.SelectedClient.MeasureTime = string.Empty;

                _viewModel.MeasureDates.Remove(_viewModel.MeasureDates.FirstOrDefault(x => x.ClientID.Equals(_viewModel.SelectedClient.Id)));

                _date.SaveMeasuresData(_viewModel.MeasureDates, _viewModel.datesPath);
                _client.SaveClientsData(_viewModel.Clients, _viewModel.clientsPath);
                _client.LoadClientsData(_viewModel.Clients, _viewModel.clientsPath);
                _viewModel.UpdateClientsData();
            }
         */

        [TestMethod]
        public void ShouldRemoveAMeasure()
        {
            // Ожидаемый результат
            ObservableCollection<Client> expected1 = new ObservableCollection<Client>()
            {
                new Client { Id = "AAA001", Name = "Name01", City = "Москва", Address = "Adress01", PhoneNumber = "PhoneNumber01", MeasureDate = "", MeasureTime = "" },    // ожидаем, что удалится только дата и время здесь
                new Client { Id = "AAA002", Name = "Name02", City = "Саратов", Address = "Adress02", PhoneNumber = "PhoneNumber02", MeasureDate = "11.11.2021", MeasureTime = "" },
                new Client { Id = "AAA003", Name = "Name03", City = "Москва", Address = "Adress03", PhoneNumber = "PhoneNumber03", MeasureDate = "11.11.2021", MeasureTime = "10:00-12:00" },
                new Client { Id = "AAA004", Name = "Name04", City = "Саратов", Address = "Adress04", PhoneNumber = "PhoneNumber04", MeasureDate = "11.11.2021", MeasureTime = "" },
                new Client { Id = "AAA005", Name = "Name05", City = "Саратов", Address = "Adress05", PhoneNumber = "PhoneNumber05", MeasureDate = "11.11.2021", MeasureTime = "" },
                new Client { Id = "AAA006", Name = "Name06", City = "Москва", Address = "Adress06", PhoneNumber = "PhoneNumber06", MeasureDate = "11.11.2021", MeasureTime = "10:00-12:00" },
                new Client { Id = "AAA007", Name = "Name07", City = "Саратов", Address = "Adress07", PhoneNumber = "PhoneNumber07", MeasureDate = "11.11.2021", MeasureTime = "" },
                new Client { Id = "AAA008", Name = "Name08", City = "Москва", Address = "Adress08", PhoneNumber = "PhoneNumber08", MeasureDate = "", MeasureTime = "" },
                new Client { Id = "AAA009", Name = "Name09", City = "Саратов", Address = "Adress09", PhoneNumber = "PhoneNumber09", MeasureDate = "11.11.2021", MeasureTime = "" },
                new Client { Id = "AAA010", Name = "Name10", City = "Саратов", Address = "Adress10", PhoneNumber = "PhoneNumber10", MeasureDate = "11.11.2021", MeasureTime = "" }
            };

            ObservableCollection<Date> expected2 = new ObservableCollection<Date>()
            {
                //new Date { ClientID = "AAA001", CityName = "Москва", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },   удаляемый замер
                new Date { ClientID = "AAA002", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA003", CityName = "Москва", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA004", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA005", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA006", CityName = "Москва", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA007", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA009", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA010", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" }
            };

            // Входящие данные
            ObservableCollection<Client> Clients = new ObservableCollection<Client>()
            {
                new Client { Id = "AAA001", Name = "Name01", City = "Москва", Address = "Adress01", PhoneNumber = "PhoneNumber01", MeasureDate = "11.11.2021", MeasureTime = "10:00-12:00" },
                new Client { Id = "AAA002", Name = "Name02", City = "Саратов", Address = "Adress02", PhoneNumber = "PhoneNumber02", MeasureDate = "11.11.2021", MeasureTime = "" },
                new Client { Id = "AAA003", Name = "Name03", City = "Москва", Address = "Adress03", PhoneNumber = "PhoneNumber03", MeasureDate = "11.11.2021", MeasureTime = "10:00-12:00" },
                new Client { Id = "AAA004", Name = "Name04", City = "Саратов", Address = "Adress04", PhoneNumber = "PhoneNumber04", MeasureDate = "11.11.2021", MeasureTime = "" },
                new Client { Id = "AAA005", Name = "Name05", City = "Саратов", Address = "Adress05", PhoneNumber = "PhoneNumber05", MeasureDate = "11.11.2021", MeasureTime = "" },
                new Client { Id = "AAA006", Name = "Name06", City = "Москва", Address = "Adress06", PhoneNumber = "PhoneNumber06", MeasureDate = "11.11.2021", MeasureTime = "10:00-12:00" },
                new Client { Id = "AAA007", Name = "Name07", City = "Саратов", Address = "Adress07", PhoneNumber = "PhoneNumber07", MeasureDate = "11.11.2021", MeasureTime = "" },
                new Client { Id = "AAA008", Name = "Name08", City = "Москва", Address = "Adress08", PhoneNumber = "PhoneNumber08", MeasureDate = "", MeasureTime = "" },
                new Client { Id = "AAA009", Name = "Name09", City = "Саратов", Address = "Adress09", PhoneNumber = "PhoneNumber09", MeasureDate = "11.11.2021", MeasureTime = "" },
                new Client { Id = "AAA010", Name = "Name10", City = "Саратов", Address = "Adress10", PhoneNumber = "PhoneNumber10", MeasureDate = "11.11.2021", MeasureTime = "" }
            };

            ObservableCollection<Date> MeasureDates = new ObservableCollection<Date>()
            {
                new Date { ClientID = "AAA001", CityName = "Москва", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA002", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA003", CityName = "Москва", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA004", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA005", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA006", CityName = "Москва", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA007", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA009", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA010", CityName = "Саратов", MeasureDate = "11.11.2021", MeasureDayOfWeek = DayOfWeek.Thursday, Interval = "10:00-12:00" }
            };

            Client SelectedClient = Clients[0];    // тут ставится удаляемый замер
            Client _client = new Client();
            Date _date = new Date();

            string clientsPath = $"{Environment.CurrentDirectory}\\/Clients.json";
            string datesPath = $"{Environment.CurrentDirectory}\\/MeasureDates.json";

            _date.SaveMeasuresData(MeasureDates, datesPath);
            MeasureDates = _date.LoadMeasureDatesData(MeasureDates, datesPath);

            ViewModel viewModel = new ViewModel(1)
            {
                SelectedClient = SelectedClient,
                MeasureDates = MeasureDates,
                Clients = Clients
            };

            RemoveMeasureDateCommand removeMeasureCommand = new RemoveMeasureDateCommand(viewModel, _client, _date);

            // Результат
            _client.SaveClientsData(Clients, clientsPath);
            removeMeasureCommand.Execute(viewModel);
            var actual1 = _client.LoadClientsData(Clients, clientsPath);
            var actual2 = _date.LoadMeasureDatesData(MeasureDates, datesPath);
            
            var result1 = expected1.SequenceEqual(actual1);
            Assert.IsTrue(result1);

            var result2 = expected2.SequenceEqual(actual2);
            Assert.IsTrue(result2);
        }
    }
}
