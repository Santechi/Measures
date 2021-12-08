using System;
using Xunit;
using System.Collections.ObjectModel;
using Test.Model;
using System.Linq;

namespace TestXUnitTests
{
    /*
     * Тестирует метод:
     * 
        public ObservableCollection<Interval> GetIntervals(ObservableCollection<City> Cities, Client SelectedClient, ObservableCollection<Interval> Intervals, DateTime CalendarDate)
        {
            return Intervals = Cities.Where(x => x.СityName.Equals(SelectedClient.City)).
                                      Select(x => x.Week.Where(y => y.DayOfWeek.Equals(CalendarDate.DayOfWeek)).
                                      Select(z => z.Intervals).FirstOrDefault()).FirstOrDefault();
        }
     */

    public class GetIntervalsTest
    {
        [Fact]
        public void ShouldGetIntervalsOnMonday()
        {
            // Ожидаемый результат
            ObservableCollection<Interval> expected = new ObservableCollection<Interval>()
            {
                new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 3 },
                new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 4 },
                new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 4 },
                new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 4 },
                new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 3 },
            };

            // Входящие данные
            Client SelectedClient = new Client()
            {
                Id = "AAA001",
                Name = "Иванов Иван Иванович",
                City = "Москва",
                Address = "ул. Пушкина, д. Колотушкина",
                PhoneNumber = "+79099099009",
                MeasureDate = "10.11.2021",
                MeasureTime = "10:00-12:00"
            };
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

            DateTime CalendarDate = new DateTime(2021, 11, 8);

            // Результат
            ObservableCollection<Interval> actual = Interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);

            Assert.True(expected.SequenceEqual(actual));
        }

        [Fact]
        public void ShouldGetIntervalsOnTuesday()
        {
            // Ожидаемый результат
            ObservableCollection<Interval> expected = new ObservableCollection<Interval>()
            {
                new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 3 },
                new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 4 },
                new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 4 },
                new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 4 },
                new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 3 },
            };

            // Входящие данные
            Client SelectedClient = new Client()
            {
                Id = "AAA001",
                Name = "Иванов Иван Иванович",
                City = "Москва",
                Address = "ул. Пушкина, д. Колотушкина",
                PhoneNumber = "+79099099009",
                MeasureDate = "10.11.2021",
                MeasureTime = "10:00-12:00"
            };
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

            DateTime CalendarDate = new DateTime(2021, 11, 9);

            // Результат
            ObservableCollection<Interval> actual = Interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);

            Assert.True(expected.SequenceEqual(actual));
        }

        [Fact]
        public void ShouldGetIntervalsOnWednesday()
        {
            // Ожидаемый результат
            ObservableCollection<Interval> expected = new ObservableCollection<Interval>()
            {
                new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 3 },
                new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 4 },
                new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 4 },
                new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 3 },
                new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 2 },
            };

            // Входящие данные
            Client SelectedClient = new Client()
            {
                Id = "AAA001",
                Name = "Иванов Иван Иванович",
                City = "Москва",
                Address = "ул. Пушкина, д. Колотушкина",
                PhoneNumber = "+79099099009",
                MeasureDate = "10.11.2021",
                MeasureTime = "10:00-12:00"
            };
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

            DateTime CalendarDate = new DateTime(2021, 11, 10);

            // Результат
            ObservableCollection<Interval> actual = Interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);

            Assert.True(expected.SequenceEqual(actual));
        }

        [Fact]
        public void ShouldGetIntervalsOnThursday()
        {
            // Ожидаемый результат
            ObservableCollection<Interval> expected = new ObservableCollection<Interval>()
            {
                new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 2 },
                new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 3 },
                new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 3 },
                new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 2 },
                new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 2 },
            };

            // Входящие данные
            Client SelectedClient = new Client()
            {
                Id = "AAA001",
                Name = "Иванов Иван Иванович",
                City = "Москва",
                Address = "ул. Пушкина, д. Колотушкина",
                PhoneNumber = "+79099099009",
                MeasureDate = "10.11.2021",
                MeasureTime = "10:00-12:00"
            };
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

            DateTime CalendarDate = new DateTime(2021, 11, 11);

            // Результат
            ObservableCollection<Interval> actual = Interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);

            Assert.True(expected.SequenceEqual(actual));
        }

        [Fact]
        public void ShouldGetIntervalsOnFriday()
        {
            // Ожидаемый результат
            ObservableCollection<Interval> expected = new ObservableCollection<Interval>()
            {
                new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 2 },
                new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 3 },
                new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 3 },
                new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 2 },
                new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 2 },
            };

            // Входящие данные
            Client SelectedClient = new Client()
            {
                Id = "AAA001",
                Name = "Иванов Иван Иванович",
                City = "Москва",
                Address = "ул. Пушкина, д. Колотушкина",
                PhoneNumber = "+79099099009",
                MeasureDate = "10.11.2021",
                MeasureTime = "10:00-12:00"
            };
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

            DateTime CalendarDate = new DateTime(2021, 11, 12);

            // Результат
            ObservableCollection<Interval> actual = Interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);

            Assert.True(expected.SequenceEqual(actual));
        }

        [Fact]
        public void ShouldGetIntervalsOnSaturday()
        {
            // Ожидаемый результат
            ObservableCollection<Interval> expected = new ObservableCollection<Interval>()
            {
                new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 2 },
                new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 2 },
                new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 2 },
                new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 0 },
                new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 0 },
            };

            // Входящие данные
            Client SelectedClient = new Client()
            {
                Id = "AAA001",
                Name = "Иванов Иван Иванович",
                City = "Москва",
                Address = "ул. Пушкина, д. Колотушкина",
                PhoneNumber = "+79099099009",
                MeasureDate = "10.11.2021",
                MeasureTime = "10:00-12:00"
            };
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

            DateTime CalendarDate = new DateTime(2021, 11, 13);

            // Результат
            ObservableCollection<Interval> actual = Interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);

            Assert.True(expected.SequenceEqual(actual));
        }
        
        [Fact]
        public void ShouldGetIntervalsOnSunday()
        {
            // Ожидаемый результат
            ObservableCollection<Interval> expected = new ObservableCollection<Interval>()
            {
                new Interval { IntervalValue = "08:00-10:00", MeasurmentDefault = 0 },
                new Interval { IntervalValue = "10:00-12:00", MeasurmentDefault = 0 },
                new Interval { IntervalValue = "12:00-14:00", MeasurmentDefault = 0 },
                new Interval { IntervalValue = "14:00-16:00", MeasurmentDefault = 0 },
                new Interval { IntervalValue = "16:00-18:00", MeasurmentDefault = 0 },
            };

            // Входящие данные
            Client SelectedClient = new Client()
            {
                Id = "AAA001",
                Name = "Иванов Иван Иванович",
                City = "Москва",
                Address = "ул. Пушкина, д. Колотушкина",
                PhoneNumber = "+79099099009",
                MeasureDate = "10.11.2021",
                MeasureTime = "10:00-12:00"
            };
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

            DateTime CalendarDate = new DateTime(2021, 11, 14);

            // Результат
            ObservableCollection<Interval> actual = Interval.GetIntervals(Cities, CityName, Intervals, CalendarDate);

            Assert.True(expected.SequenceEqual(actual));
        }
    }

}
