using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class TripType
    {
        private readonly Fare fare;

        public TripType(Fare fare)
        {
            this.fare = fare;
        }

        public OnewayTrip Oneway()
        {
            return new OnewayTrip(fare);
        }

        public RoundTrip RoundTrip()
        {
            return new RoundTrip(fare);
        }

        public Trip valueOf(string name)
        {
            var method = typeof(TripType).GetMethod(name);
            return method.Invoke(this, null) as Trip;
        }

    }
}
