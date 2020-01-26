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
            var actual = sut.calculateFare(new Departure("Tokyo"),
                                                        new Destination("Himeji"),
                                                        "Nozomi",
                                                        "Free",
                                                        "Adult",
                                                        "Oneway",
                                                        new System.DateTime(2020, 4, 1),
                                                        1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FromTokyoToShinOsakaWithReservedSeatChildCase()
        {
            FaresRepositoryMock mock = new FaresRepositoryMock();
            FareSystemService sut = new FareSystemService(mock.withFares().Build());
            var actual = sut.calculateFare(new Departure("Tokyo"),
                                                        new Destination("ShinOsaka"),
                                                        "Hikari",
                                                        "Reserved",
                                                        "Child",
                                                        "Oneway",
                                                        new System.DateTime(2020, 4, 1),
                                                        1);
            Assert.AreEqual(7190, actual);
        }

        [TestMethod]
        public void FromTokyoToHimejiWithNozomiFreeChildRoundTripCase()
        {
            FaresRepositoryMock mock = new FaresRepositoryMock();
            FareSystemService sut = new FareSystemService(mock.withFares().Build());
            var expectedRoundTripDiscountBasicFare = 9000;
            var expected = (expectedRoundTripDiscountBasicFare + ((5920 + 530) - 530)) * 2;
            var actual = sut.calculateFare(new Departure("Tokyo"),
                                                        new Destination("Himeji"),
                                                        "Nozomi",
                                                        "Free",
                                                        "Adult",
                                                        "RoundTrip",
                                                        new System.DateTime(2020, 4, 1),
                                                        1);
            Assert.AreEqual(expected, actual);
        }

        private const int fareOfFromTokyoToShinOsakaAdultHikariOneway = 14400;

        private int discount(int value, double rate)
        {
            return (int)System.Math.Floor((value * rate) * 0.1) * 10;
        }

        [TestMethod]
        public void GroupDiscountAtOrdinaryTermSmallScaleGroupCase()
        {
            FaresRepositoryMock mock = new FaresRepositoryMock();
            FareSystemService sut = new FareSystemService(mock.withFares().Build());
            var actual = sut.calculateFare(new Departure("Tokyo"),
                                                        new Destination("ShinOsaka"),
                                                        "Hikari",
                                                        "Reserved",
                                                        "Adult",
                                                        "Oneway",
                                                        new System.DateTime(2020, 12, 20),
                                                        8);
            var expected = (fareOfFromTokyoToShinOsakaAdultHikariOneway - discount(fareOfFromTokyoToShinOsakaAdultHikariOneway, 0.15)) * 8;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GroupDiscountAtPeakTermOrdinaryGroupCase()
        {
            FaresRepositoryMock mock = new FaresRepositoryMock();
            FareSystemService sut = new FareSystemService(mock.withFares().Build());
            var actual = sut.calculateFare(new Departure("Tokyo"),
                                                        new Destination("ShinOsaka"),
                                                        "Hikari",
                                                        "Reserved",
                                                        "Adult",
                                                        "Oneway",
                                                        new System.DateTime(2020, 1, 1),
                                                        31);
            var oneAmount = fareOfFromTokyoToShinOsakaAdultHikariOneway - discount(fareOfFromTokyoToShinOsakaAdultHikariOneway, 0.10);
            var expected = (oneAmount * 31) - oneAmount;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GroupDiscountAtPeakTermLergeScaleGroupCase()
        {
            FaresRepositoryMock mock = new FaresRepositoryMock();
            FareSystemService sut = new FareSystemService(mock.withFares().Build());
            var actual = sut.calculateFare(new Departure("Tokyo"),
                                                        new Destination("ShinOsaka"),
                                                        "Hikari",
                                                        "Reserved",
                                                        "Adult",
                                                        "Oneway",
                                                        new System.DateTime(2020, 1, 1),
                                                        155);
            var oneAmount = fareOfFromTokyoToShinOsakaAdultHikariOneway - discount(fareOfFromTokyoToShinOsakaAdultHikariOneway, 0.10);
            var expected = (oneAmount * 155) - (oneAmount * 3);
            Assert.AreEqual(expected, actual);
        }

    }
}
