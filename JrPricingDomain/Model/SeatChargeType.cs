using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class SeatChargeType
    {
        private readonly HikariCharge hikariCharge;
        private readonly FreeSeatDiscount freeSeatDiscount;

        public SeatChargeType(HikariCharge hikariCharge, FreeSeatDiscount freeSeatDiscount)
        {
            this.hikariCharge = hikariCharge;
            this.freeSeatDiscount = freeSeatDiscount;
        }

        public ReservedSeatCharge Reserved()
        {
            return new ReservedSeatCharge(hikariCharge);
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
