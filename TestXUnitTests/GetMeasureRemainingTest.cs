using System;
using Xunit;
using System.Collections.ObjectModel;
using Test.Model;

namespace TestXUnitTests
{
    /*
     * Тестирует метод:
     * 
        public int GetMeasureRemaining(int DatesPerCity, int getDefault, ObservableCollection<Date> MeasureDates, ObservableCollection<City> Cities, ObservableCollection<Interval> Intervals, Client SelectedClient, Interval SelectedInterval, DateTime CalendarDate)    // Метод, возвращающий количество оставшихся замеров на день в конкретном городе
        {
            if (SelectedClient.City == "Москва")
            {
                if (SelectedInterval == null)
                {
                    SelectedInterval = Intervals.First();
                }

                DatesPerCity = MeasureDates.Count(x => x.MeasureDate.Equals(CalendarDate.ToShortDateString()) && x.CityName.Equals(SelectedClient.City) && x.Interval.Equals(SelectedInterval.IntervalValue));
                getDefault = Cities.Where(x => x.СityName.Equals(SelectedClient.City)).Select(x => x.Week).FirstOrDefault().Where(x => x.DayOfWeek.Equals(CalendarDate.DayOfWeek)).Select(x => x.Intervals.Where(y => y.IntervalValue.Equals(SelectedInterval.IntervalValue)).Select(z => z.MeasurmentDefault).FirstOrDefault()).First();
            }
            else
            {
                DatesPerCity = MeasureDates.Count(x => x.MeasureDate.Equals(CalendarDate.ToShortDateString()) && x.CityName.Equals(SelectedClient.City));
                getDefault = Cities.
                          Where(x => x.СityName.Equals(SelectedClient.City)).
                          Select(x => x.Week).FirstOrDefault().
                          Where(x => x.DayOfWeek.Equals(CalendarDate.DayOfWeek)).
                          Select(x => x.MeasurmentDefault).First();
            }

            return getDefault - DatesPerCity;
        }
    }
    */

    public class GetMeasureRemainingTest
    {
        [Fact]
        public void ShouldGetMeasureRemaining()
        {
            // Ожидаемый результат
            int expected = 2;

            // Входящие данные
            Interval Interval = new Interval();
            Date Date = new Date();
            string CityName = "Москва";

            ObservableCollection<Interval> Intervals = new ObservableCollection<Interval>();
            
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
            
            ObservableCollection<Date> MeasureDates = new ObservableCollection<Date>()
            {
                new Date { ClientID = "AAA001", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA002", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "10:00-12:00" },
            };

            DateTime CalendarDate = new DateTime(2021, 11, 10);
            Intervals = Interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);

            Interval = Intervals[1];

            // Результат
            int actual = Date.GetMeasureRemaining(default, default, MeasureDates, Cities, Intervals, CityName, Interval, CalendarDate);

            Assert.True(actual == expected);
        }
    }
}
