using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class OnewayBasicFare : BasicFareWithTripType
    {
         public readonly BasicFare basicFare;

        public OnewayBasicFare(BasicFare basicFare)
        {
            this.basicFare = basicFare;
        }

        public int value => basicFare.value;
    }
}
