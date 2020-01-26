using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class Ticket
    {
        private readonly Trip trip;
        private readonly BoardingDate boardingDate;
        private readonly NumberOfPeople numberOfPeople;
        public Ticket(Trip trip, BoardingDate boardingDate, NumberOfPeople numberOfPeople)
        {
            this.trip = trip;
            this.boardingDate = boardingDate;
            this.numberOfPeople = numberOfPeople;
        }

        public int Amount()
        {
            if (numberOfPeople.isGroupDiscountNotApplicable())
            {
                return trip.value() * numberOfPeople.value;
            }

            GroupDiscount groupDiscount = new GroupDiscount(trip, boardingDate);

            GroupType groupType = GroupType.valueOf(numberOfPeople);
            NumberOfPeople discountApplicableNumber = groupType.groupDiscountApplicableNumber();

            var discountedFare = trip.value() - groupDiscount.value();
            var amout = (discountedFare * numberOfPeople.value) - (discountedFare * discountApplicableNumber.value);
            return amout;
        }
    }
}
