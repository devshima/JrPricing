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
            Assert.AreEqual(expected, sut.calculateFare(new Departure("Tokyo"), new Destination("Himeji"), "Nozomi", "Free", "Adult"));
        }

        [TestMethod]
        public void FromTokyoToShinOsakaWithReservedSeatChildCase()
        {
            FaresRepositoryMock mock = new FaresRepositoryMock();
            FareSystemService sut = new FareSystemService(mock.withFares().Build());
            Assert.AreEqual(7190, sut.calculateFare(new Departure("Tokyo"), new Destination("ShinOsaka"), "Hikari", "Reserved", "Child"));
        }

    }
}
