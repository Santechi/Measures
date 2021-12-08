using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Interval
    {
        public string IntervalValue { get; set; }
        public int MeasurmentDefault { get; set; }

        public ObservableCollection<Interval> GetIntervals(ObservableCollection<City> Cities, string CityName, ObservableCollection<Interval> Intervals, DateTime CalendarDate)
        {
            return Intervals = Cities.Where(x => x.СityName.Equals(CityName)).
                                      Select(x => x.Week.Where(y => y.DayOfWeek.Equals(CalendarDate.DayOfWeek)).
                                      Select(z => z.Intervals).FirstOrDefault()).FirstOrDefault();
        }
       
        public override bool Equals(object obj)
        {
            if (null == obj || obj.GetType() != typeof(Interval))
                return false;

            var interval = obj as Interval;
            return interval.IntervalValue == IntervalValue && interval.MeasurmentDefault == MeasurmentDefault;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
