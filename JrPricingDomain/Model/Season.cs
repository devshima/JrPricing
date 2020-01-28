using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public interface Season
    {
        //public static Season offPeak = new Season(new ReservedSeatSeasonVariable(-200));
        //public static Season peak = new Season(new ReservedSeatSeasonVariable(200));
        //public static Season regular = new Season(new ReservedSeatSeasonVariable(0));

        //private readonly ReservedSeatSeasonVariable reservedSeatSeasonVariable;

        //public Season(ReservedSeatSeasonVariable reservedSeatSeasonVariable)
        //{
        //    this.reservedSeatSeasonVariable = reservedSeatSeasonVariable;
        //}

        int variableAmount();

    }
}
