using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public interface GroupType
    {
        NumberOfPeople groupDiscountApplicableNumber();
        public static GroupType valueOf(NumberOfPeople numberOfPeople)
        {
            if (numberOfPeople.isLargeScaleGroup()) { return new LargeScaleGroup(numberOfPeople); };
            if (numberOfPeople.isOrdinaryGroup()) { return new OrdinaryGroup(); };
            return new SmallScaleGroup();
        }
    }
}
