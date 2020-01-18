using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class RailWayDistance
    {
        public readonly int value;

        public RailWayDistance(int value)
        {
            this.value = value;
        }

        public bool isDiscountDistance()
        {
            return this.value >= 601;
        }

    }
}
