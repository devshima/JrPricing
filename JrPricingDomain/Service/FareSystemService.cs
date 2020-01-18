﻿using System;
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
                                              string tripName)
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

            return trip.value();
        }
    }
}
