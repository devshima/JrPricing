using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
   public class BasicFareType
    {
        private readonly BasicFare basicFare;
        private readonly RailWayDistance railWayDistance;

        public BasicFareType(BasicFare basicFare, RailWayDistance railWayDistance)
        {
            this.basicFare = basicFare;
            this.railWayDistance = railWayDistance;
        }

        public BasicFareWithTripType Oneway()
        {
            return new OnewayBasicFare(basicFare);
        }

        public BasicFareWithTripType RoundTrip()
        {
            return createBasicFareForRoundTrip();
        }

        private BasicFareWithTripType createBasicFareForRoundTrip()
        {
            if (this.railWayDistance.isDiscountDistance())
            {
                return new RoundTripDiscountedOnewayBasicFare(this.basicFare);
            }
            return new OnewayBasicFare(this.basicFare);
        }

        public BasicFareWithTripType valueOf(string name)
        {
            var method = typeof(BasicFareType).GetMethod(name);
            return method.Invoke(this, null) as BasicFareWithTripType;
        }
    }
}
