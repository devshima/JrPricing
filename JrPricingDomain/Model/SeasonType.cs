using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class SeasonType
    {
        public static Season valueOf(BoardingDate boardingDate)
        {
            switch (boardingDate)
            {
                case BoardingDate boarding when PeakSeason.during(boarding):
                    return new PeakSeason();
                case BoardingDate boarding when OffPeakSeason.during(boarding):
                    return new OffPeakSeason();
                default:
                    return new ReqularSeason();
            }
        }
    }
}
