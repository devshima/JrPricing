using Microsoft.VisualStudio.TestTools.UnitTesting;
using JrPricingDomain.Service;
using JrPricingDomain.Model;

namespace JrPricingDomainUnitTest
{
    [TestClass]
    public class FareSystemServiceTests
    {
        [TestMethod]
        public void FromTokyoToShinOsakaWithNozomiFreeChildCase()
        {
            FaresRepositoryMock mock = new FaresRepositoryMock();
            FareSystemService sut = new FareSystemService(mock.withFares().Build());
            var expected = 10010 + ((5920 + 530) - 530);
            Assert.AreEqual(expected, sut.calculateFare(new Departure("Tokyo"), 
                                                                                     new Destination("Himeji"),
                                                                                     "Nozomi",
                                                                                     "Free", 
                                                                                     "Adult",
                                                                                     "Oneway"));
        }

        [TestMethod]
        public void FromTokyoToShinOsakaWithReservedSeatChildCase()
        {
            FaresRepositoryMock mock = new FaresRepositoryMock();
            FareSystemService sut = new FareSystemService(mock.withFares().Build());
            Assert.AreEqual(7190, sut.calculateFare(new Departure("Tokyo"), 
                                                                              new Destination("ShinOsaka"), 
                                                                              "Hikari", 
                                                                              "Reserved", 
                                                                              "Child",
                                                                              "Oneway"));
        }

        [TestMethod]
        public void FromTokyoToShinOsakaWithNozomiFreeChildRoundTripCase()
        {
            FaresRepositoryMock mock = new FaresRepositoryMock();
            FareSystemService sut = new FareSystemService(mock.withFares().Build());
            var expectedRoundTripDiscountBasicFare = 9000;
            var expected = (expectedRoundTripDiscountBasicFare + ((5920 + 530) - 530)) * 2;
            Assert.AreEqual(expected, sut.calculateFare(new Departure("Tokyo"),
                                                                                     new Destination("Himeji"),
                                                                                     "Nozomi",
                                                                                     "Free",
                                                                                     "Adult",
                                                                                     "RoundTrip"));
        }

    }
}
