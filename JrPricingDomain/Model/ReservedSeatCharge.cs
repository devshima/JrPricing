using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class ReservedSeatCharge :SeatCharge
    {
        private readonly HikariCharge hikariCharge;
        private readonly Season season;

        public ReservedSeatCharge(HikariCharge hikariCharge, Season season)
        {
            this.hikariCharge = hikariCharge;
            this.season = season;
        }

        public int value => hikariCharge.value + season.variableAmount();

        public string label => "指定席";
    }
}
