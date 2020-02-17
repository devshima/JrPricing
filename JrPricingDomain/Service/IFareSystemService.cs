using JrPricingDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Service
{
    public interface IFareSystemService
    {
        public int calculateFare(Departure departure,
                                         Destination destination,
                                         string superExpressName,
                                         string seatName,
                                         string fareName,
                                         string tripName,
                                         DateTime boardingDate,
                                         int numberOfPeopleValue);
    }
}
