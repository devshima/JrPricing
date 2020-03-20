using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingApplication
{
    public class FareCalculateCommand
    {

        public FareCalculateCommand(
            string departure,
            string destination,
            string superExpressName,
            string seatName,
            string fareName,
            string tripName,
            DateTime boardingDate,
            int numberOfPeopleValue)
        {
            this.departure = departure;
            this.destination = destination;
            this.superExpressName = superExpressName;
            this.seatName  = seatName;
            this.fareName = fareName;
            this.tripName = tripName;
            this.boardingDate = boardingDate;
            this.numberOfPeopleValue = numberOfPeopleValue;
        }

        public string departure { get;}
        public string destination { get;}
        public string superExpressName { get; }
        public string seatName { get; }
        public string fareName { get; }
        public string tripName { get; }
        public DateTime boardingDate { get;}
        public int numberOfPeopleValue { get;}
    }
}
