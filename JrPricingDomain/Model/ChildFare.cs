using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class ChildFare : Fare
    {
        public BasicFare basicFare { get; }

        public SuperExpressSurcharge superExpressSurcharge { get; }

        private const double discountRate = 0.5;
        private const double roundDownNumber = 0.1;

        public ChildFare(BasicFare basicFare, SuperExpressSurcharge superExpressSurcharge)
        {
            this.basicFare = basicFare;
            this.superExpressSurcharge = superExpressSurcharge;
        }
        public int value()
        {
            return calculateChildFare(basicFare.value) + calculateChildFare(superExpressSurcharge.value);
        }

        public int calculateChildFare(int value)
        {
            return (int)Math.Floor((value * discountRate) * roundDownNumber) * 10;
        }

    }
}
