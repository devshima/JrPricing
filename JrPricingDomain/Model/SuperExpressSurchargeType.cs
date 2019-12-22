using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JrPricingDomain.Model
{
    public class SuperExpressSurchargeType
    {
        private readonly SeatCharge seatCharge;
        private readonly NozomiAdditionalCharge nozomiAdditionalCharge;

        public SuperExpressSurchargeType(SeatCharge seatCharge, NozomiAdditionalCharge nozomiAdditionalCharge)
        {
            this.seatCharge = seatCharge;
            this.nozomiAdditionalCharge = nozomiAdditionalCharge;
        }

        public  Hikari Hikari()
        {
            return new Hikari(seatCharge);
        }

        public  Nozomi Nozomi()
        {
            return new Nozomi(seatCharge, nozomiAdditionalCharge);
        }

        public SuperExpressSurcharge valueOf(string name)
        {
            var method = typeof(SuperExpressSurchargeType).GetMethod(name);
            return method.Invoke(this, null) as SuperExpressSurcharge;
        }

    }
}
