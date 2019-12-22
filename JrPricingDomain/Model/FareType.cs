using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class FareType
    {
        private readonly BasicFare basicFare;
        private readonly SuperExpressSurcharge superExpressSurcharge;

        public FareType(BasicFare basicFare, SuperExpressSurcharge superExpressSurcharge)
        {
            this.basicFare = basicFare;
            this.superExpressSurcharge = superExpressSurcharge;
        }

        public AdultFare Adult()
        {
            return new AdultFare(basicFare, superExpressSurcharge);
        }

        public ChildFare Child()
        {
            return new ChildFare(basicFare, superExpressSurcharge);
        }

        public Fare valueOf(string name)
        {
            var method = typeof(FareType).GetMethod(name);
            return method.Invoke(this, null) as Fare;
        }

    }
}
