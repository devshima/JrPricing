using System;
using JrPricingDomain.Model;
using JrPricingDomain.Repository;

namespace JrPricingApplication
{
    public class FareApplicationService
    {
        private IFaresRepository faresRepository;

        public FareApplicationService(IFaresRepository faresRepository)
        {
            this.faresRepository = faresRepository;
        }

        public FareCalculateResult calculate(FareCalculateCommand command)
        {
            FareByRoute fareByRoute = faresRepository.GetFareByRoute(
                new Departure(command.departure),
                new Destination(command.destination));

            Season season = SeasonType.valueOf(new BoardingDate(command.boardingDate));

            SeatChargeType seatType = new SeatChargeType(fareByRoute.hikariCharge, new FreeSeatDiscount(530), season);
            SeatCharge seat = seatType.valueOf(command.seatName);

            SuperExpressSurchargeType superExpressType = new SuperExpressSurchargeType(seat, fareByRoute.nozomiAdditionalCharge);
            SuperExpressSurcharge superExpressSurcharge = superExpressType.valueOf(command.superExpressName);

            BasicFareType basicFareType = new BasicFareType(fareByRoute.basicFare, fareByRoute.railWayDistance);
            BasicFareWithTripType basicFareWithTripType = basicFareType.valueOf(command.tripName);

            FareType fareType = new FareType(basicFareWithTripType, superExpressSurcharge);
            Fare fare = fareType.valueOf(command.fareName);

            TripType tripType = new TripType(fare);
            Trip trip = tripType.valueOf(command.tripName);

            Ticket ticket = new Ticket(trip, new BoardingDate(command.boardingDate), new NumberOfPeople(command.numberOfPeopleValue));
            return new FareCalculateResult(ticket);
        }

    }
}
