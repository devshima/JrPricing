using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class RoundTrip : Trip
    {
        private Fare departingFare;
        private Fare returningFare;

        public RoundTrip(Fare fare)
        {
            this.departingFare = fare;
            this.returningFare = fare;
        }

        public int value() => this.departingFare.value() + this.returningFare.value();

    }
}
