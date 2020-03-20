using Microsoft.VisualStudio.TestTools.UnitTesting;
using JrPricingApplication;

namespace JrPricingApplicationServiceTests
{
    [TestClass]
    public class FareSystemServiceTests
    {
        [TestMethod]
        public void FromTokyoToShinOsakaWithNozomiFreeChildCase()
        {
            var mock = new FaresRepositoryMock();
            var sut = new FareApplicationService(mock.withFares().Build());
            var expected = 10010 + ((5920 + 530) - 530);

            var command = new FareCalculateCommand(
                "Tokyo",
                "Himeji",
                "Nozomi",
                 "Free",
                 "Adult",
                 "Oneway",
                 new System.DateTime(2020, 4, 1),
                 1
                );

            var result = sut.calculate(command);
            Assert.AreEqual(expected, result.amount());
        }

        [TestMethod]
        public void FromTokyoToShinOsakaWithReservedSeatChildCase()
        {
            FaresRepositoryMock mock = new FaresRepositoryMock();
            var sut = new FareApplicationService(mock.withFares().Build());

            var command = new FareCalculateCommand(
                "Tokyo",
                "ShinOsaka",
                "Hikari",
                 "Reserved",
                 "Child",
                 "Oneway",
                 new System.DateTime(2020, 4, 1),
                 1
                );

            var result = sut.calculate(command);
            Assert.AreEqual(7190, result.amount());
        }

        [TestMethod]
        public void FromTokyoToHimejiWithNozomiFreeChildRoundTripCase()
        {
            var mock = new FaresRepositoryMock();
            var sut = new FareApplicationService(mock.withFares().Build());

            var expectedRoundTripDiscountBasicFare = 9000;
            var expected = (expectedRoundTripDiscountBasicFare + ((5920 + 530) - 530)) * 2;

            var command = new FareCalculateCommand(
                "Tokyo",
                "Himeji",
                "Nozomi",
                "Free",
                "Adult",
                "RoundTrip",
                new System.DateTime(2020, 4, 1),
                1
                );

            var result = sut.calculate(command);
            Assert.AreEqual(expected, result.amount());
        }

        private const int fareOfFromTokyoToShinOsakaAdultHikariOneway = 14400;

        private int discount(int value, double rate)
        {
            return (int)System.Math.Floor((value * rate) * 0.1) * 10;
        }

        [TestMethod]
        public void GroupDiscountAtOrdinaryTermSmallScaleGroupCase()
        {
            var mock = new FaresRepositoryMock();
            var sut = new FareApplicationService(mock.withFares().Build());

            var command = new FareCalculateCommand(
                "Tokyo",
                "ShinOsaka",
                "Hikari",
                "Reserved",
                "Adult",
                "Oneway",
                new System.DateTime(2020, 12, 20),
                8
                );

            var result = sut.calculate(command);

            var expected = (fareOfFromTokyoToShinOsakaAdultHikariOneway - discount(fareOfFromTokyoToShinOsakaAdultHikariOneway, 0.15)) * 8;
            Assert.AreEqual(expected, result.amount());
        }

        [TestMethod]
        public void GroupDiscountAtPeakTermOrdinaryGroupCase()
        {
            var mock = new FaresRepositoryMock();
            var sut = new FareApplicationService(mock.withFares().Build());

            var command = new FareCalculateCommand(
                "Tokyo",
                "ShinOsaka",
                "Hikari",
                "Reserved",
                "Adult",
                "Oneway",
                new System.DateTime(2020, 1, 1),
                31
                );

            var result = sut.calculate(command);
            var seasonAmount = fareOfFromTokyoToShinOsakaAdultHikariOneway + 200;
            var oneAmount = seasonAmount - discount(seasonAmount, 0.10);
            var expected = (oneAmount * 31) - oneAmount;
            Assert.AreEqual(expected, result.amount());
        }

        [TestMethod]
        public void GroupDiscountAtPeakTermLergeScaleGroupCase()
        {
            var mock = new FaresRepositoryMock();
            var sut = new FareApplicationService(mock.withFares().Build());

            var command = new FareCalculateCommand(
                "Tokyo",
                "ShinOsaka",
                "Hikari",
                "Reserved",
                "Adult",
                "Oneway",
                new System.DateTime(2020, 1, 1),
                155
                );

            var result = sut.calculate(command);

            var seasonAmount = fareOfFromTokyoToShinOsakaAdultHikariOneway + 200;
            var oneAmount = seasonAmount - discount(seasonAmount, 0.10);
            var expected = (oneAmount * 155) - (oneAmount * 3);
            Assert.AreEqual(expected, result.amount());
        }

    }
}
