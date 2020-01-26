using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class NumberOfPeople
    {
        public readonly int value;

        public NumberOfPeople(int value)
        {
            this.value = value;
        }

        public bool isGroupDiscountNotApplicable()
        {
            return this.value < 8;
        }

        public bool isGroupDiscountApplicable()
        {
            return this.value >= 8;
        }

        public bool isOrdinaryGroup()
        {
            return this.value >= 31 && this.value <= 50;
        }

        public bool isLargeScaleGroup()
        {
            return this.value >= 51;
        }

    }
}
