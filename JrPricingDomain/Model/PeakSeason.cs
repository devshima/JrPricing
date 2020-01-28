using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class PeakSeason : Season
    {
        public readonly ReservedSeatSeasonVariable reservedSeatSeasonVariable = 
            new ReservedSeatSeasonVariable(200);
        public int variableAmount()
        {
            return reservedSeatSeasonVariable.value;
        }
        public static bool during(BoardingDate boardingDate)
        {
            if (boardingDate.value.Month == 12 && boardingDate.value.Day >= 25) { return true; };
            return boardingDate.value.Month == 1 && boardingDate.value.Day <= 10;
        }

    }
}
