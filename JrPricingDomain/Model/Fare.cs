using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public  interface Fare
    {
        public BasicFareWithTripType basicFare { get; }
        public SuperExpressSurcharge superExpressSurcharge { get; }

        int value();

        string label { get; }
    }
}
