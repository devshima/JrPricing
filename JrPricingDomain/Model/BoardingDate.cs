using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class BoardingDate
    {
        public readonly DateTime value;
      
        public BoardingDate(DateTime value)
        {
            this.value = value;
        }

        public bool duringNewYearHolidaysPeriod()
        {
            return NewYearHolidaysPeriod.during(this);
        }

    }
}
