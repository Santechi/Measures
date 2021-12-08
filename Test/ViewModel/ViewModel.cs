using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


using Test.Model;
using Test.ViewModel.Commands;

namespace Test.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private City City = new City();
        private Client Client = new Client();
        private Date Date = new Date();
        private Interval Interval = new Interval();

        private ObservableCollection<Client> _clients;
        private ObservableCollection<City> _cities;
        private ObservableCollection<Date> _measureDates;
        private ObservableCollection<Interval> _intervals;  // Коллекция интервалов для Москвы. Сами интервалы находятся в файле "Cities.json"

        private BaseCommand _newMeasureCommand;
        private BaseCommand _removeMeasureDateCommand;

        private Client _selectedClient;
        private Interval _selectedInterval;
        private bool _intervalsEnabled;
        private DateTime _date;
        private string CityName = "Москва";

        public string clientsPath = $"{Environment.CurrentDirectory}\\/Clients.json";
        public string citiesPath = $"{Environment.CurrentDirectory}\\/Cities.json";
        public string datesPath = $"{Environment.CurrentDirectory}\\/MeasureDates.json";
        

        public ViewModel()
        {
            Cities = City.LoadCitiesData(_cities, citiesPath);
            Clients = Client.LoadClientsData(_clients, clientsPath);
            MeasureDates = Date.LoadMeasureDatesData(_measureDates, datesPath);
            Intervals = Interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);

            // При старте программы, в datagrid по умолчанию выбран последний элемент (клиент). Проверка города выбранного элемента (клиента)
            // Также тут можно поменять город или сделать интервалы доступными не только для Москвы

            if (SelectedClient.City == CityName)
            {
                IntervalsEnabled = true;
                SelectedInterval = Intervals.First();

                OnPropertyChanged("IntervalsEnabled");
            }
            else
            {
                IntervalsEnabled = false;
                SelectedInterval = Intervals.First();

                OnPropertyChanged("IntervalsEnabled");
            }
            _date = DateTime.Now;   // отображает текущую дату на календаре
        }

        public ViewModel(int i)
        {
        }

        public Client SelectedClient
        {
            get
            {
                if (_selectedClient == null)
                {
                    return Clients.Last();
                }
                else
                    return _selectedClient;
            }
            set
            {
                _selectedClient = value;

                if (SelectedClient.MeasureDate != string.Empty)
                    CalendarDate = Convert.ToDateTime(SelectedClient.MeasureDate);
                else
                    CalendarDate = DateTime.Today;

                // Если выбранный клиент живет в Москве, то для него открывается доступ к выбору временного интервала, в противном случае доступа к выбору временного интервала нет
                if (SelectedClient.City == "Москва")
                    IntervalsEnabled = true;
                else
                    IntervalsEnabled = false;

                OnPropertyChanged("Intervals");
                OnPropertyChanged("IntervalsEnabled");
                OnPropertyChanged("SelectedClient");
                OnPropertyChanged("MeasureRemaining");
            }
        }

        public Interval SelectedInterval
        {
            get
            {
                return _selectedInterval;
            }
            set
            {
                _selectedInterval = value;

                OnPropertyChanged("Intervals");
                OnPropertyChanged("SelectedClient");
                OnPropertyChanged("MeasureRemaining");
            }
        }

        public bool IntervalsEnabled    // биндится для доступа combobox в форме
        {
            get
            {
                return _intervalsEnabled;
            }
            set
            {
                _intervalsEnabled = value;
            }
        }

        public int MeasureRemaining     // биндится для textblock в форме
        {
            get
            {
                return Date.GetMeasureRemaining(default, default, MeasureDates, Cities, Intervals, SelectedClient.City, SelectedInterval, CalendarDate);
            }
        }

        public DateTime CalendarDate
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged("CalendarDate");
                OnPropertyChanged("DateString");
                OnPropertyChanged("MeasureRemaining");
            }
        }

        public string DateString    // биндится для textblock в форме
        {
            get
            {
                return CalendarDate.ToShortDateString();
            }
        }

        #region COMMANDS

        public BaseCommand NewMeasureCommand
        {
            get
            {
                if (_newMeasureCommand == null)
                {
                    _newMeasureCommand = new NewMeasureCommand(this, Client, Date);
                }
                return _newMeasureCommand;
            }
        }

        public BaseCommand RemoveMeasureCommand
        {
            get
            {
                if (_removeMeasureDateCommand == null)
                {
                    _removeMeasureDateCommand = new RemoveMeasureDateCommand(this, Client, Date);
                }
                return _removeMeasureDateCommand;
            }
        }
        #endregion

        #region COLLECTIONS

        public ObservableCollection<Interval> Intervals
        {
            get
            {
                return _intervals;
            }
            set
            {
                _intervals = value;
                OnPropertyChanged("Intervals");
                OnPropertyChanged("MeasureRemaining");
            }
        }

        public ObservableCollection<Date> MeasureDates
        {
            get
            {
                if (_measureDates == null)
                {
                    _measureDates = new ObservableCollection<Date>();
                    return _measureDates;
                }
                else
                    return _measureDates;
            }
            set
            {
                if (_measureDates == value)
                    return;
                else
                    _measureDates = value;
                OnPropertyChanged("Dates");
                OnPropertyChanged("MeasureRemaining");
            }
        }

        public ObservableCollection<Client> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                if (_clients == value)
                    return;
                else
                    _clients = value;
                OnPropertyChanged("Clients");
                OnPropertyChanged("MeasureRemaining");
            }
        }

        public ObservableCollection<City> Cities
        {
            get
            {
                return _cities;
            }
            set
            {
                if (_cities != value)
                {
                    _cities = value;
                    OnPropertyChanged("Cities");
                    OnPropertyChanged("MeasureRemaining");
                }
            }
        }

        #endregion


        public ObservableCollection<Client> UpdateClientsData(ObservableCollection<Client> Clients, string path)
        {
            string clientsJSON = File.ReadAllText(path);
            Clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(clientsJSON);

            return this.Clients = Clients;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
