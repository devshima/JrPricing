using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public interface SuperExpressSurcharge
    {
        public int value { get; }
        public string label { get; }

        public SeatCharge getSeatCharge { get; }
    }
}
