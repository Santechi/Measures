using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    class Slot
    { 
        public Client Client { get; set; }
        public DateTime DayOfMeasurment { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public int MeasurmentDefault { get; set; }
        public int MeasurmentRemain { get; set; }
    }
}
