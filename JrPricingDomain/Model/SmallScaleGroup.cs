using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class SmallScaleGroup : GroupType
    {
        public NumberOfPeople groupDiscountApplicableNumber()
        {
            return new NumberOfPeople(0);
        }
    }
}
