using System;
using System.Collections.Generic;
using System.Text;
using JrPricingDomain.Model;

namespace JrPricingDomain.Repository
{
    public interface IFaresRepository
    {
        public FareByRoute GetFareByRoute(Departure departure, Destination destination);
    }
}
