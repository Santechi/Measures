using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Date   // Класс используется, как отметка замера в MeasureDates.json
    {
        public string ClientID { get; set; }
        public string CityName { get; set; } 
        public string MeasureDate { get; set; }
        public DayOfWeek MeasureDayOfWeek { get; set; }
        public string Interval { get; set; }

        public ObservableCollection<Date> LoadMeasureDatesData(ObservableCollection<Date> MeasureDates, string path)
        {
            string measureDatesJSON = File.ReadAllText(path);
            MeasureDates = JsonConvert.DeserializeObject<ObservableCollection<Date>>(measureDatesJSON);

            return MeasureDates;
        }

        public void SaveMeasuresData(ObservableCollection<Date> dates, string path)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                string output = JsonConvert.SerializeObject(dates);
                writer.Write(output);
            }
        }

        public void AddNewMeasureToCollection(ObservableCollection<Date> dates, Date date)  // метод, добавляющий в коллекцию новый замер
        {
            dates.Add(date);
        }

        public int GetMeasureRemaining(int DatesPerCity, int getDefault, ObservableCollection<Date> MeasureDates, ObservableCollection<City> Cities, ObservableCollection<Interval> Intervals, string CityName, Interval SelectedInterval, DateTime CalendarDate)    // Метод, возвращающий количество оставшихся замеров на день в конкретном городе
        {
            if (CityName == "Москва")
            {
                if (SelectedInterval == null)
                {
                    SelectedInterval = Intervals.First();
                }

                DatesPerCity = MeasureDates.Count(x => x.MeasureDate.Equals(CalendarDate.ToShortDateString()) && x.CityName.Equals(CityName) && x.Interval.Equals(SelectedInterval.IntervalValue));
                getDefault = Cities.Where(x => x.СityName.Equals(CityName)).Select(x => x.Week).FirstOrDefault().Where(x => x.DayOfWeek.Equals(CalendarDate.DayOfWeek)).Select(x => x.Intervals.Where(y => y.IntervalValue.Equals(SelectedInterval.IntervalValue)).Select(z => z.MeasurmentDefault).FirstOrDefault()).First();
            }
            else
            {
                DatesPerCity = MeasureDates.Count(x => x.MeasureDate.Equals(CalendarDate.ToShortDateString()) && x.CityName.Equals(CityName));
                getDefault = Cities.
                          Where(x => x.СityName.Equals(CityName)).
                          Select(x => x.Week).FirstOrDefault().
                          Where(x => x.DayOfWeek.Equals(CalendarDate.DayOfWeek)).
                          Select(x => x.MeasurmentDefault).First();
            }

            return getDefault - DatesPerCity;
        }

        public override bool Equals(object obj)
        {
            if (null == obj || obj.GetType() != typeof(Date))
                return false;

            var measureDate = obj as Date;
            return measureDate.ClientID == ClientID && measureDate.CityName == CityName && measureDate.MeasureDate == MeasureDate && measureDate.MeasureDayOfWeek == MeasureDayOfWeek && measureDate.Interval == Interval;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
