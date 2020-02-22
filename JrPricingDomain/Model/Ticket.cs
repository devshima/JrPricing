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
            return groupDiscountedAmount();
        }

        public GroupDiscount groupDiscount()
        {
            return new GroupDiscount(trip, boardingDate);
        }

        public GroupType groupType()
        {
           return GroupType.valueOf(numberOfPeople);
        }

        public NumberOfPeople discountApplicableNumber()
        {
            return this.groupType().groupDiscountApplicableNumber();
        }

        public int groupDiscountedFare()
        {
            return this.trip.value() - this.groupDiscount().value();
        }　

        private int groupDiscountedAmount()
        {
            var discountedFare = this.groupDiscountedFare();
            return (discountedFare * numberOfPeople.value) - (discountedFare * this.discountApplicableNumber().value);
        }

    }
}
