using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class Nozomi : SuperExpressSurcharge
    {
        private readonly SeatCharge seatCharge;
        private readonly NozomiAdditionalCharge nozomiAdditionalCharge;
        public Nozomi(SeatCharge seatCharge, NozomiAdditionalCharge nozomiAdditionalCharge)
        {
            this.seatCharge = seatCharge;
            this.nozomiAdditionalCharge = nozomiAdditionalCharge;
        }

        public int value => seatCharge.value + nozomiAdditionalCharge.value;

        public string label =>"のぞみ";

        public SeatCharge getSeatCharge => this.seatCharge;
    }
}
