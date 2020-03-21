using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Moq;
using JrPricingDomain.Model;
using JrPricingDomain.Repository;

namespace JrPricingApplicationServiceTests
{
    class FaresRepositoryMock
    {
        private Mock<IFaresRepository> thisMock = new Mock<IFaresRepository>();
        public List<FareByRoute> fareByRoutes { get; private set; }
        public FaresRepositoryMock withFares()
        {
            fareByRoutes = new List<FareByRoute>() {
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

            thisMock.Setup(m => m.GetFareByRoute(It.IsAny<Departure>(), It.IsAny<Destination>()))
                          .Returns((Departure departure, Destination destination) => 
                                fareByRoutes.FirstOrDefault(f => f.departure.value == departure.value && 
                                                                                      f.destination.value == destination.value));
                                        
            return this;
        }
        public IFaresRepository Build()
        {
            return thisMock.Object;
        }
    }
}
