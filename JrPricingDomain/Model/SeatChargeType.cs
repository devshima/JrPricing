using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class SeatChargeType
    {
        private readonly HikariCharge hikariCharge;
        private readonly FreeSeatDiscount freeSeatDiscount;
        private readonly Season season;

        public SeatChargeType(HikariCharge hikariCharge, FreeSeatDiscount freeSeatDiscount, Season season)
        {
            this.hikariCharge = hikariCharge;
            this.freeSeatDiscount = freeSeatDiscount;
            this.season = season;
        }

        public ReservedSeatCharge Reserved()
        {
            return new ReservedSeatCharge(hikariCharge, season);
        }

        public FreeSeatCharge Free()
        {
            return new FreeSeatCharge(hikariCharge, freeSeatDiscount);
        }

        public SeatCharge valueOf(string name)
        {
            var method = typeof(SeatChargeType).GetMethod(name);
            return method.Invoke(this, null) as SeatCharge;
        }

    }
}
