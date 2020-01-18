using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class FareType
    {
        private readonly BasicFareWithTripType basicFareType;
        private readonly SuperExpressSurcharge superExpressSurcharge;

        public FareType(BasicFareWithTripType basicFare, SuperExpressSurcharge superExpressSurcharge)
        {
            this.basicFareType = basicFare;
            this.superExpressSurcharge = superExpressSurcharge;
        }

        public AdultFare Adult()
        {
            return new AdultFare(basicFareType, superExpressSurcharge);
        }

        public ChildFare Child()
        {
            return new ChildFare(basicFareType, superExpressSurcharge);
        }

        public Fare valueOf(string name)
        {
            var method = typeof(FareType).GetMethod(name);
            return method.Invoke(this, null) as Fare;
        }

    }
}
