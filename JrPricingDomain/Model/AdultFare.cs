using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class AdultFare : Fare
    {
        public BasicFare basicFare { get; }

        public SuperExpressSurcharge superExpressSurcharge { get; }

        public AdultFare(BasicFare basicFare, SuperExpressSurcharge superExpressSurcharge)
        {
            this.basicFare = basicFare;
            this.superExpressSurcharge = superExpressSurcharge;
        }

        public int value()
        {
            return  basicFare.value + superExpressSurcharge.value;
        }
    }
}
