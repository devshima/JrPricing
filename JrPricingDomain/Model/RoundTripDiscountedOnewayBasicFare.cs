using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class RoundTripDiscountedOnewayBasicFare : BasicFareWithTripType
    {
        private readonly BasicFare basicFare;
        private const double discountRate = 0.9;
        private const double roundDownNumber = 0.1;

        public RoundTripDiscountedOnewayBasicFare(BasicFare basicFare)
        {
            this.basicFare = basicFare;
        }

        public int value =>  (int) Math.Floor((this.basicFare.value* discountRate) * roundDownNumber) * 10;

    }
}
