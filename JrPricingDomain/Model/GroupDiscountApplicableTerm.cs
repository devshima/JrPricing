using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class GroupDiscountApplicableTerm
    {
        private const int StartMonth = 12;
        private const int StartDay = 21;
        private const int EndMonth = 1;
        private const int EndDay = 10;

        public static bool isGroupDiscountApplicableDay(BoardingDate boardingDate)
        {
            if (boardingDate.value.Month == StartMonth && boardingDate.value.Day >= StartDay) { return true; };
            return boardingDate.value.Month == EndMonth && boardingDate.value.Day <= EndDay;
        }

    }
}
