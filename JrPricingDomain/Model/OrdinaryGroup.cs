using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class OrdinaryGroup : GroupType
    {
        public NumberOfPeople groupDiscountApplicableNumber()
        {
            return new NumberOfPeople(1);
        }
    }
}
