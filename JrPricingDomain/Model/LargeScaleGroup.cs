using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class LargeScaleGroup : GroupType
    {
        private readonly NumberOfPeople numberOfPeople;
        public LargeScaleGroup(NumberOfPeople numberOfPeople)
        {
            this.numberOfPeople = numberOfPeople;
        }

        public string label => "大規模";

        public NumberOfPeople groupDiscountApplicableNumber()
        {
            return new NumberOfPeople(this.numberOfPeople.value / 50);
        }
    }
}
