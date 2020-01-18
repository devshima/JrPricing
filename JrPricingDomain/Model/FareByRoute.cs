using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class FareByRoute
    {
        public readonly Departure departure;
        public readonly Destination destination;
        public readonly BasicFare basicFare;
        public readonly HikariCharge hikariCharge;
        public readonly NozomiAdditionalCharge nozomiAdditionalCharge;
        public readonly RailWayDistance railWayDistance;

        public FareByRoute(Departure departure,
                                        Destination destination,
                                        BasicFare basicFare,
                                        HikariCharge hikariCharge,
                                        NozomiAdditionalCharge nozomiAdditionalCharge,
                                        RailWayDistance railWayDistance)

        {
            this.departure = departure;
            this.destination = destination;
            this.basicFare = basicFare;
            this.hikariCharge = hikariCharge;
            this.nozomiAdditionalCharge = nozomiAdditionalCharge;
            this.railWayDistance = railWayDistance;
        }

    }
}
