using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class SmallScaleGroup : GroupType
    {
        public string label => "小規模";

        public NumberOfPeople groupDiscountApplicableNumber()
        {
            return new NumberOfPeople(0);
        }
    }
}
