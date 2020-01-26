using System;
using System.Collections.Generic;
using System.Text;
using JrPricingDomain.Model;
using JrPricingDomain.Repository;

namespace JrPricingDomain.Service
{
    public class FareSystemService
    {
        private readonly IFaresRepository _faresRepository;

        public FareSystemService(IFaresRepository faresRepository)
        {
           _faresRepository = faresRepository;
        }

        public int calculateFare(Departure departure, 
                                         Destination destination,  
                                         string superExpressName, 
                                         string seatName, 
                                         string fareName,
                                         string tripName, 
                                         DateTime boardingDate,
                                         int numberOfPeopleValue)
        {
            FareByRoute fareByRoute = _faresRepository.GetFareByRoute(departure, destination);

            SeatChargeType seatType = new SeatChargeType(fareByRoute.hikariCharge, new FreeSeatDiscount(530));
            SeatCharge seat = seatType.valueOf(seatName);

            SuperExpressSurchargeType superExpressType = new SuperExpressSurchargeType(seat, fareByRoute.nozomiAdditionalCharge);
            SuperExpressSurcharge superExpressSurcharge = superExpressType.valueOf(superExpressName);

            BasicFareType basicFareType = new BasicFareType(fareByRoute.basicFare, fareByRoute.railWayDistance);
            BasicFareWithTripType basicFareWithTripType = basicFareType.valueOf(tripName);

            FareType fareType = new FareType(basicFareWithTripType, superExpressSurcharge);
            Fare fare = fareType.valueOf(fareName);

            TripType tripType = new TripType(fare);
            Trip trip = tripType.valueOf(tripName);

            NumberOfPeople numberOfPeople = new NumberOfPeople(numberOfPeopleValue);

            GroupType groupType = GroupType.valueOf(numberOfPeople);
            NumberOfPeople discountApplicableNumber = groupType.groupDiscountApplicableNumber();

            GroupDiscountType groupDiscount = GroupDiscountType.valueOf(trip, new BoardingDate(boardingDate), numberOfPeople);

            var discountedFare = trip.value() - groupDiscount.value();
            var amout = (discountedFare * numberOfPeople.value) - (discountedFare * discountApplicableNumber.value);
            return amout;
        }
    }
}
