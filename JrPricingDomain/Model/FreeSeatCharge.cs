using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class FreeSeatCharge : SeatCharge
    {
        private readonly HikariCharge hikariCharge;
        private readonly FreeSeatDiscount freeSeatDiscount;
        public FreeSeatCharge(HikariCharge hikariCharge, FreeSeatDiscount freeSeatDiscount)
        {
            this.hikariCharge = hikariCharge;
            this.freeSeatDiscount = freeSeatDiscount;
        }

        public int value => this.hikariCharge.value - freeSeatDiscount.value;

        public string label => "自由席";
    }
}
