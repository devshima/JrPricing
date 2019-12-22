using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class ReservedSeatCharge :SeatCharge
    {
        private readonly HikariCharge hikariCharge;

        public ReservedSeatCharge(HikariCharge hikariCharge)
        {
            this.hikariCharge = hikariCharge;
        }

        public int value => hikariCharge.value;

    }
}
