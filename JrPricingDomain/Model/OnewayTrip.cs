using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class OnewayTrip : Trip
    {
        private Fare fare;

        public OnewayTrip(Fare fare)
        {
            this.fare = fare;
        }

        public int value() => fare.value();
    }
}
