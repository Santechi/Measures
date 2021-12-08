using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace Test.Model
{
    public class Day   // Класс использовался, чтобы формировать неделю
    {
        public DayOfWeek DayOfWeek { get; set; }
        public int MeasurmentDefault { get; set; }
        public ObservableCollection<Interval> Intervals { get; set; }
        
        public override bool Equals(object obj)
        {
            if (null == obj || obj.GetType() != typeof(Day))
                return false;

            var day = obj as Day;
            return day.DayOfWeek == DayOfWeek && day.MeasurmentDefault == MeasurmentDefault && day.Intervals.Equals(Intervals);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
    }
}
