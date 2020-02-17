using System;
using System.Collections.Generic;
using System.Text;
using JrPricingDomain.Model;
using JrPricingDomain.Repository;
using System.Linq;

namespace JrPricingInfrastructure.Repository
{
    public class FaresRepository : IFaresRepository
    {
        private List<FareByRoute> fareByRoutes = new List<FareByRoute>() {
                    new FareByRoute(new Departure("Tokyo"),
                                                  new Destination("ShinOsaka"),
                                                  new BasicFare(8910),
                                                  new HikariCharge(5490),
                                                  new NozomiAdditionalCharge(320),
                                                  new RailWayDistance(533)),
                    new FareByRoute(new Departure("Tokyo"),
                                                  new Destination("Himeji"),
                                                  new BasicFare(10010),
                                                  new HikariCharge(5920),
                                                  new NozomiAdditionalCharge(530),
                                                  new RailWayDistance(644))
                };

        public FareByRoute GetFareByRoute(Departure departure, Destination destination)
        {
            return fareByRoutes.Single(f => f.departure.value == departure.value &&
                                                            f.destination.value == destination.value);
        }
    }
}
