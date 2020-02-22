using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class ReqularSeason : Season
    {
        public string label => "通常期";

        public int variableAmount()
        {
            return 0;
        }
    }
}
