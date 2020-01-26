using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public interface GroupDiscountType
    {
        int value();
        public static GroupDiscountType valueOf(Trip trip, BoardingDate boardingDate, NumberOfPeople numberOfPeople)
        {
            if (numberOfPeople.isGroupDiscountApplicable())
            {
                return new GroupDiscount(trip, boardingDate);
            }
            return new NotGroupDiscount();
        }

    }
}
