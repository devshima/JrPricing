using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public interface Trip
    {
        public int value();
        public string label { get; }
    }
}
